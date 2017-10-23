using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6.Analysers.Generic
{
    class GenericLoopAnalyser
    {
        public int getLoopAmount(CSharpSyntaxTree syntaxTree, string requirements, int amount)
        {
            var root = syntaxTree.GetRoot();
            var MyClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var MyMethod = MyClass.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var MyVariable = MyMethod.DescendantNodes().OfType<VariableDeclarationSyntax>().First();
            var MyLoop = MyMethod.DescendantNodes().OfType<ForStatementSyntax>();

            Console.WriteLine(MyClass.Identifier.ToString());
            Console.WriteLine(MyMethod.Identifier.ToString());
            Console.WriteLine(MyVariable.ToString());

            foreach(var declaration in MyLoop)
            {
                Console.WriteLine(declaration.ToString());
            }

            return 5;
        }
    }
}
