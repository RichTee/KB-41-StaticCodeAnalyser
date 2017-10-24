using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using ConsoleApplication6.Analysers.Generic;

namespace ConsoleApplication6.Analysers
{
    class Assignment915 : IAnalyser
    {
        protected GenericLoopAnalyser genericLoopAnalyser = new GenericLoopAnalyser();
        protected ResponseService responseService = new ResponseService();

        public string Analyse(CSharpCompilation compiledCode, string requirements)
        {
            throw new NotImplementedException();
        }

        public string Analyse(CSharpSyntaxTree syntaxTree, string requirements)
        {
            bool result = genericLoopAnalyser.IsLoopingAmount(syntaxTree, 5);
            return responseService.CreateRequirementOutput("requirements['name']", "requirements['description']", result, "");
        }
    }
}
