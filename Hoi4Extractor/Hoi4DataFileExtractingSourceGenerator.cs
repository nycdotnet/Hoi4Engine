using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;

namespace Hoi4Extractor;

[Generator]
public class Hoi4DataFileExtractingSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            // Uncomment this line to attach the debugger on build.
            Debugger.Launch();
        }
#endif

        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: NodePredicate,
            transform: static (ctx, _) => (ClassDeclarationSyntax)ctx.Node
        ).Where(m => m is not null);

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

        foreach (var attributeList in syntax.AttributeLists)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                // might be able to tidy this up a bit...
                var name = attribute.Name.NormalizeWhitespace().ToFullString();
                if (name is "Hoi4DataFile" or "Hoi4DataFileAttribute")
                {
                    return true;
                }
            }
        }

        return false;
    }


    //var arg = attribute.ArgumentList.Arguments.FirstOrDefault();
    //if (arg is not null) {
    //    if (arg.Expression is ExpressionSyntax es)
    //    {
    //        es.getv
    //    }
    //    //if (arg.Expression is StringLiteralExpression lit)
    //    //{

    //    //}
    //    //var argValue = arg.NormalizeWhitespace().ToFullString();
    //    //var argName = arg.NameEquals.Name.Identifier.ValueText;
    //}
    //Debug.Write("hello");
    //Console.WriteLine("hi");
    //extraComments.Add("hi");



    private void Execute(SourceProductionContext context, (Compilation Left, ImmutableArray<ClassDeclarationSyntax> Right) tuple)
    {
        var (compilation, syntaxes) = tuple;

        var names = new List<string>();

        foreach (var syntax in syntaxes)
        {
            var symbol = compilation
                .GetSemanticModel(syntax.SyntaxTree)
                .GetDeclaredSymbol(syntax) as INamedTypeSymbol;


            names.Add($"\"{symbol.ToDisplayString()}\"");
        }
        //{{string.Join("\n", extraComments)}}
        var theCode = $$"""
            namespace Hoi4Data.Generated;

            /*
            
            */
            public static class MyGeneratedClass {
                public static List<string> Names = new() { {{string.Join(",", names)}} };
                
            }
            """;

        ////public static string comments = "{{(names.Count == 0)}}";

        context.AddSource("MyGeneratedClass.g.cs", theCode);
    }
}
