using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using ConsoleApplication6.Analysers.Generic;

namespace ConsoleApplication6.Analysers
{
    class Assignment914 : IAnalyser
    {
        protected ResponseService responseService = new ResponseService();
        protected GenericLoopAnalyser genericLoopAnalyser = new GenericLoopAnalyser();

        public string Analyse(CSharpCompilation compiledCode, string requirements)
        {
            throw new NotImplementedException();
        }

        public string Analyse(CSharpSyntaxTree syntaxTree, string requirements)
        {
            // normally you want to digest the information in the requirements json and dynamically call functions instead of hardcoded.
            bool result = genericLoopAnalyser.HasLoop(syntaxTree);
            return responseService.CreateRequirementOutput("requirements['name']", "requirements['description']", result, "");
        }
    }
}
