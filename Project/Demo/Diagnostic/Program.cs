using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using Microsoft.CodeAnalysis.Emit;

namespace ConsoleApplication3
{
    class Program
    {
        private static MetadataReference[] references = new MetadataReference[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
        };


        private static readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);

        static void Main(string[] args)
        {
            var source = @"namespace ConsoleApplication3
{
    public class Output { public statict void Main() { } }
}
";
            var parsedSyntaxTree = CSharpSyntaxTree.ParseText(source);
            var compilation = CSharpCompilation.Create("Test.dll", new SyntaxTree[] { parsedSyntaxTree }, references, DefaultCompilationOptions);

            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (var diag in failures)
                    {
                        Console.Error.WriteLine("{0}: {1}", diag.Id, diag.GetMessage());
                    }
                }
                else
                {
                    Console.Error.WriteLine("Failed");
                }
            }

            Console.Read();
        }
    }
}
