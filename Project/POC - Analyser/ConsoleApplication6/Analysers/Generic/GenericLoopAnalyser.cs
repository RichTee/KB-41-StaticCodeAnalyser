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
        protected ResponseService responseService = new ResponseService();

        private int GetLoopAmount(CSharpSyntaxTree syntaxTree, string requirements, int amount)
        {
            var root = syntaxTree.GetRoot();
            var MyClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            var MyMethod = MyClass.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var MyVariable = MyMethod.DescendantNodes().OfType<VariableDeclarationSyntax>().First();
            var MyLoop = MyMethod.DescendantNodes().OfType<ForStatementSyntax>();

            Console.WriteLine(MyClass.Identifier.ToString());
            Console.WriteLine(MyMethod.Identifier.ToString());
            Console.WriteLine(MyVariable.ToString());

            int counter = -1;

            foreach (var declaration in MyLoop)
            {
                counter = 5;
            }

            return counter;
        }

        public string IsLoopingAmount(CSharpSyntaxTree syntaxTree, string requirements, int amount)
        {
            int loopedAmount = GetLoopAmount(syntaxTree, requirements, amount);
            bool status = loopedAmount == 5 ? true : false;
            return responseService.CreateRequirementOutput("requirements['name']", "requirements['description']", status, "");
        }
    }
}
