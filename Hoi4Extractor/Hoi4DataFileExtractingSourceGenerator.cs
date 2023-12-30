using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            // Debugger.Launch();
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
            // NOTE: The suggestion is to load the files via MSBuild
            using var pdxFile = new MemoryStream(File.ReadAllBytes(Path.Combine(Hoi4Root, fileSpec.RelativePath)));
            var len = pdxFile.Length;
#pragma warning restore RS1035 // Do not use APIs banned for analyzers

            var code = new StringBuilder();
            code.Append($$"""
                namespace {{fileSpec.Namespace}};

                public partial class {{fileSpec.ClassName}} {
                    public static string RelativePath => "{{fileSpec.RelativePath}}";
                }

                """);

            context.AddSource($"{fileSpec.ClassName}.g.cs", code.ToString());
        }
    }

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
                            ClassName = classSyntax.Identifier.ValueText
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

                        if (!string.IsNullOrEmpty(toGen.RelativePath))
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
