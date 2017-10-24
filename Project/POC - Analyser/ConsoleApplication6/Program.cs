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

/**
 * IMPORTANT INFORMATION:
 * This Project is complementary to the Statische Code Analyse project.
 * When this part is completed it should be integrated into that project.
 */

namespace ConsoleApplication6
{
    class Program
    {
        private static CompilerService compilerService = new CompilerService();
        private static Assignment915 opdracht915 = new Assignment915();

        static void Main(string[] args)
        {
            // Id, source, requirements are variables given by the Gamification Project.
            // Requirements should be in JSON format.
            string id = "914";
            string source = @"namespace ConsoleApplication3
{
    public class Output { public statitc void Main() { string test = 10; for (int i = 0; i < 5; i++) { Console.WriteLine(1);}} }
}
";
            string requirements = "ownRequirementsFormat";
            string result = AnalyseAssignment(id, source, requirements);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string AnalyseAssignment(string id, string source, string requirements)
        {
            IAnalyser assignment = GetAnalyser(id);
            CSharpSyntaxTree syntaxTree = compilerService.CreateSyntaxTree(source);
            var result = assignment.Analyse(syntaxTree, requirements);

            return result;
        }

        private static IAnalyser GetAnalyser(string id)
        {
            switch (id)
            {
                case "914":
                    return new Assignment914();
                case "915":
                    return new Assignment915();
                default:
                    return null;

            }
        }
    }
}
