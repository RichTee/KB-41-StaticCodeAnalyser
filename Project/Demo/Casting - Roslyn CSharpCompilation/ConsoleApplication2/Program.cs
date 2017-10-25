using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
class MyClass
{
    int firstVariable, = 0;
    Double secondVariable = (Double) firstVariable;
}");

            var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("MyCompilation",
                syntaxTrees: new[] { tree }, references: new[] { mscorlib });

            var fields = tree.GetRoot().DescendantNodes().OfType<FieldDeclarationSyntax>();

            //Get a particular variable in a field
            var second = fields.SelectMany(n => n.Declaration.Variables).Where(n => n.Identifier.ValueText == "secondVariable").Single();

            if (second.GetText().ToString().Contains("(Double) firstVariable"))
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(second.GetText());
            }

            Console.ReadKey();
        }
    }
}
