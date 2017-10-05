using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
public class Sample
{
   public void Foo()
   {
        int unused = 0;
        int used = 1;
        System.Console.Write(used);
   }
}");

            var Mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("MyCompilation",
                syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
            var model = compilation.GetSemanticModel(tree);

            var methodBody = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().Single().Body;
            DataFlowAnalysis result = model.AnalyzeDataFlow(methodBody);

            var variablesDeclared = result.VariablesDeclared;
            var variablesRead = result.ReadInside.Union(result.ReadOutside);

            var unused = variablesDeclared.Except(variablesRead);

            foreach (var variable in unused)
            {
                Console.WriteLine(variable);
            }
            Console.Read();
        }
    }
}
