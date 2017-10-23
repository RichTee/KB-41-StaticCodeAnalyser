using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using ConsoleApplication6.Analysers;

namespace ConsoleApplication6
{
    class Program
    {
        private static CompilerService compilerService = new CompilerService();
        private static Opdracht915 opdracht915 = new Opdracht915();

        static void Main(string[] args)
        {
            string source = @"namespace ConsoleApplication3
{
    public class Output { public statitc void Main() { string test = 10; for (int i = 0; i < 5; i++) { Console.WriteLine(1);}} }
}
";
            string requirements = "ownRequirementsFormat";
            CSharpSyntaxTree syntaxTree = compilerService.CreateSyntaxTree(source);
            var result = opdracht915.Analyse(syntaxTree, requirements);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
