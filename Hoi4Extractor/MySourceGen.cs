using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;

namespace Hoi4Extractor;

[Generator]
public class MySourceGen : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }
#endif

        var provider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: NodePredicate,
            transform: static (ctx, _) => (ClassDeclarationSyntax)ctx.Node
        ).Where(m => m is not null);

        var compilation = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(compilation, Execute);
    }

    //private static List<string> extraComments = new();

    private static bool NodePredicate(SyntaxNode node, CancellationToken _)
    {
        //Debug.Write("hello");
        //Console.WriteLine("hi");
        //extraComments.Add("hi");

        return node is ClassDeclarationSyntax;
    }

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
