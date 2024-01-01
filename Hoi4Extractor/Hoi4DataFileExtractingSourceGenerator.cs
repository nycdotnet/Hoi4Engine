using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pdoxcl2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hoi4Extractor;

[Generator]
public partial class Hoi4DataFileExtractingSourceGenerator : IIncrementalGenerator
{
    private static readonly string[] Hoi4DataFileAttributeNames = [nameof(Hoi4DataFileAttribute), "Hoi4DataFile"];

    public string Hoi4Root { get; }

    public Hoi4DataFileExtractingSourceGenerator()
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            // Uncomment this line to attach the debugger on build.
             //Debugger.Launch();
        }
#endif

#pragma warning disable RS1035 // Do not use APIs banned for analyzers
        Hoi4Root = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), @"Steam/steamapps/common/Hearts of Iron IV"));
#pragma warning restore RS1035 // Do not use APIs banned for analyzers

    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: NodePredicate,
            transform: static (ctx, _) => (ClassDeclarationSyntax)ctx.Node
        ).Where(static s => s is not null);

        var compilation = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(compilation, Execute);
    }

    private static bool NodePredicate(SyntaxNode node, CancellationToken _)
    {
        if (node is not ClassDeclarationSyntax syntax)
        {
            return false;
        }

        if (syntax.AttributeLists is { Count: 0 })
        {
            return false;
        }

        if (!(syntax.Modifiers.OfType<SyntaxToken>().Any(m => m.ValueText is "partial") && syntax.Modifiers.OfType<SyntaxToken>().Any(m => m.ValueText is "public")))
        {
            return false;
        }

        if (syntax.BaseList?.Types.Any(t => t.Type.ToString() is nameof(SubunitCollection) or nameof(EquipmentCollection)) is false or null)
        {
            return false;
        }

        foreach (var attributeList in syntax.AttributeLists)
        {
            foreach (var attribute in attributeList.Attributes.Where(a => a.Name is IdentifierNameSyntax))
            {
                var name = ((IdentifierNameSyntax)attribute.Name).Identifier.ValueText;
                if (Hoi4DataFileAttributeNames.Contains(name))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void Execute(SourceProductionContext context, (Compilation Left, ImmutableArray<ClassDeclarationSyntax> Right) tuple)
    {
        var (compilation, classes) = tuple;
        var filesToExtract = GetFilesToExtract(compilation, classes);

        foreach (var fileSpec in filesToExtract)
        {
#pragma warning disable RS1035 // Do not use APIs banned for analyzers
            // NOTE: The suggestion is to load the files via MSBuild - not sure yet how to do this.
            using var pdxFile = new MemoryStream(File.ReadAllBytes(Path.Combine(Hoi4Root, fileSpec.RelativePath)));
#pragma warning restore RS1035 // Do not use APIs banned for analyzers            

            string code = "";

            if (fileSpec.Type == typeof(SubunitCollection))
            {
                var subunits = ParadoxParser.Parse(pdxFile, new SubunitCollection());
                code = $$"""
                using Hoi4Extractor;
                namespace {{fileSpec.Namespace}};

                public partial class {{fileSpec.ClassName}} {
                    // generated {{DateTime.UtcNow}}
                    public static string RelativePath => "{{fileSpec.RelativePath}}";
                    public {{fileSpec.ClassName}}()
                    {
                {{outputSubunits(subunits)}}
                    }
                }

                """;
            }
            else if (fileSpec.Type == typeof(EquipmentCollection))
            {
                var equipment = ParadoxParser.Parse(pdxFile, new EquipmentCollection());
                equipment.Normalize();
                code = $$"""
                using Hoi4Extractor;
                namespace {{fileSpec.Namespace}};

                public partial class {{fileSpec.ClassName}} {
                    // generated {{DateTime.UtcNow}}
                    public static string RelativePath => "{{fileSpec.RelativePath}}";
                    public {{fileSpec.ClassName}}()
                    {
                {{outputEquipment(equipment)}}
                    }
                }

                """;
            }
            
            if (!string.IsNullOrEmpty(code))
            {
                context.AddSource($"{Path.GetDirectoryName(fileSpec.RelativePath)}/{fileSpec.ClassName}.g.cs", code);
            }
        }

        static string outputEquipment(EquipmentCollection equipment)
        {
            var sb = new StringBuilder();
            sb.Append("        Equipment e;\n");
            foreach (var e in equipment)
            {
                sb.Append($$"""
                                    e = new Equipment("{{e.Name}}");
                            {{outputEquipmentProperties(e)}}
                                    {{(e.UnsupportedTokens.Any() ? $"// unsupported tokens: {string.Join(",", e.UnsupportedTokens)}" : "")}}
                                    Equipment.Add(e);

                            """);
            }
            return sb.ToString();
        }

        static string outputEquipmentProperties(Equipment e)
        {
            var sb = new StringBuilder();

            foreach (var property in typeof(Equipment).GetProperties().Where(p => !SpecialProperties.Contains(p.Name)))
            {
                if (property.PropertyType == typeof(string))
                {
                    var p = (string)property.GetValue(e);
                    sb.Append($"        e.{property.Name} = \"{p}\";\n");
                }
                else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    var p = property.GetValue(e);
                    if (p is not null)
                    {
                        sb.Append($"        e.{property.Name} = {p};\n");
                    }
                }
                else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                {
                    var p = property.GetValue(e);
                    if (p is not null)
                    {
                        sb.Append($"        e.{property.Name} = {p}m;\n");
                    }
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    var p = property.GetValue(e);
                    if (p is not null)
                    {
                        var boolCode = ((bool)property.GetValue(e)) ? "true" : "false";
                        sb.Append($"        e.{property.Name} = {boolCode};\n");
                    }
                }
                else if (property.PropertyType == typeof(IList<string>))
                {
                    var p = (List<string>)property.GetValue(e);
                    if (p is not null and not { Count: 0 })
                    {
                        sb.Append($"        e.{property.Name} = [{string.Join(",", p.Select(element => $"\"{element}\""))}];\n");
                    }
                }
                else if (property.PropertyType == typeof(IDictionary<string, int>))
                {
                    var p = (Dictionary<string, int>)property.GetValue(e);
                    if (p is not null and not { Count: 0 })
                    {
                        sb.Append($"        e.{property.Name} = new Dictionary<string, int>();\n");
                        foreach (var kvp in p)
                        {
                            sb.Append($"        e.{property.Name}[\"{kvp.Key}\"] = {kvp.Value};\n");
                        }
                    }
                }
                else
                {
                    sb.Append($"        // type of {property.PropertyType} ({property.Name}) not supported.\n");
                }
            }
            return sb.ToString();
        }

        static string outputSubunits(SubunitCollection subunits)
        {
            var sb = new StringBuilder();
            sb.Append("        Subunit u;\n");
            foreach (var su in subunits)
            {
                sb.Append($$"""
                                    u = new Subunit("{{su.Name}}");
                            {{outputSubunitProperties(su)}}
                                    {{(su.UnsupportedTokens.Any() ? $"// unsupported tokens: {string.Join(",", su.UnsupportedTokens)}" : "")}}
                                    Subunits.Add(u);

                            """);
            }
            return sb.ToString();
        }

        static string outputSubunitProperties(Subunit su)
        {
            var sb = new StringBuilder();

            foreach (var property in typeof(Subunit).GetProperties().Where(p => !SpecialProperties.Contains(p.Name)))
            {
                if (property.PropertyType == typeof(string))
                {
                    var p = (string)property.GetValue(su);
                    sb.Append($"        u.{property.Name} = \"{p}\";\n");
                }
                else if (property.PropertyType == typeof(int))
                {
                    var p = property.GetValue(su).ToString();
                    sb.Append($"        u.{property.Name} = {p};\n");
                }
                else if (property.PropertyType == typeof(decimal))
                {
                    var p = property.GetValue(su).ToString();
                    sb.Append($"        u.{property.Name} = {p}m;\n");
                }
                else if (property.PropertyType == typeof(bool))
                {
                    var p = ((bool)property.GetValue(su)) ? "true" : "false";
                    sb.Append($"        u.{property.Name} = {p};\n");
                }
                else if (property.PropertyType == typeof(List<string>))
                {
                    var p = (List<string>)property.GetValue(su);
                    if (p is not null and not { Count : 0 })
                    {
                        sb.Append($"        u.{property.Name}.AddRange([{string.Join(",", p.Select(element => $"\"{element}\""))}]);\n");
                    }
                }
                else if (property.PropertyType == typeof(IDictionary<string, int>))
                {
                    var p = (Dictionary<string, int>)property.GetValue(su);
                    if (p is not null and not { Count: 0 })
                    {
                        sb.Append($"        u.{property.Name} = new Dictionary<string, int>();\n");
                        foreach (var kvp in p)
                        {
                            sb.Append($"        u.{property.Name}[\"{kvp.Key}\"] = {kvp.Value};\n");
                        }
                    }
                }
                else if (property.PropertyType == typeof(IDictionary<string, decimal>))
                {
                    var p = (Dictionary<string, decimal>)property.GetValue(su);
                    if (p is not null and not { Count: 0 })
                    {
                        sb.Append($"        u.{property.Name} = new Dictionary<string, decimal>();\n");
                        foreach (var kvp in p)
                        {
                            sb.Append($"        u.{property.Name}[\"{kvp.Key}\"] = {kvp.Value}m;\n");
                        }
                    }
                }
                else
                {
                    sb.Append($"        // type of {property.PropertyType} ({property.Name}) not supported.\n");
                }
            }
            return sb.ToString();
        }
    }

    private static readonly HashSet<string> SpecialProperties = ["Name", "UnsupportedTokens"];

    private static List<DataFileToExtract> GetFilesToExtract(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes)
    {
        var result = new List<DataFileToExtract>();
        foreach (var classSyntax in classes.Where(c => c.Parent is NamespaceDeclarationSyntax))
        {
            var symbol = compilation
                .GetSemanticModel(classSyntax.SyntaxTree)
                .GetDeclaredSymbol(classSyntax) as INamedTypeSymbol;

            foreach (var list in classSyntax.AttributeLists)
            {
                foreach (var attribute in list.Attributes.Where(a => a.Name is IdentifierNameSyntax))
                {
                    var name = ((IdentifierNameSyntax)attribute.Name).Identifier.ValueText;
                    if (Hoi4DataFileAttributeNames.Contains(name))
                    {
                        var toGen = new DataFileToExtract
                        {
                            Namespace = ((QualifiedNameSyntax)((NamespaceDeclarationSyntax)classSyntax.Parent).Name).NormalizeWhitespace().ToFullString(),
                            ClassName = classSyntax.Identifier.ValueText,
                            Type = classSyntax.BaseList.Types.Any(t => t.Type.ToString() == nameof(SubunitCollection)) ? typeof(SubunitCollection) :
                                    classSyntax.BaseList.Types.Any(t => t.Type.ToString() == nameof(EquipmentCollection)) ? typeof(EquipmentCollection) :
                                    null
                        };

                        for (var i = 0; i < attribute.ArgumentList.Arguments.Count; i++)
                        {
                            var arg = attribute.ArgumentList.Arguments[i];
                            if (arg.NameColon is null)
                            {
                                if (i == 0)
                                {
                                    toGen.RelativePath = ((LiteralExpressionSyntax)arg.Expression).Token.ValueText;
                                }
                            }
                            else
                            {
                                if (arg.NameColon.Expression is IdentifierNameSyntax ins && ins.Identifier.ValueText == "RelativePath")
                                {
                                    toGen.RelativePath = ((LiteralExpressionSyntax)arg.Expression).Token.ValueText;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(toGen.RelativePath) && toGen.Type is not null)
                        {
                            result.Add(toGen);
                        }
                    }
                }
            }
        }
        return result;
    }
}
