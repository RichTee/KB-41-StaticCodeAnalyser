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
        private int GetLoopAmount(CSharpSyntaxTree syntaxTree, int amount)
        {
            var root = syntaxTree.GetRoot();
            var MyClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var MyMethod = MyClass.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var MyVariable = MyMethod.DescendantNodes().OfType<VariableDeclarationSyntax>().First();
            var MyLoop = MyMethod.DescendantNodes().OfType<ForStatementSyntax>();

            int counter = -1;

            foreach (var declaration in MyLoop)
            {
                counter = 5;
            }

            return counter;
        }

        public bool HasLoop(CSharpSyntaxTree syntaxTree)
        {
            var root = syntaxTree.GetRoot();
            // These variables can be put into one, for examplary purposes they have been seperated.
            var MyClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var MyMethod = MyClass.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var MyLoop = MyMethod.DescendantNodes().OfType<ForStatementSyntax>();

            return MyLoop.Count() > 0;
        }


        public bool IsLoopingAmount(CSharpSyntaxTree syntaxTree, int amount)
        {
            int loopedAmount = GetLoopAmount(syntaxTree, amount);
            bool status = loopedAmount == 5 ? true : false;
            return status;
        }
    }
}
