using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using ConsoleApplication6.Analysers.Generic;

namespace ConsoleApplication6.Analysers
{
    class Opdracht915 : IAnalyser
    {
        protected GenericLoopAnalyser genericLoopAnalyser = new GenericLoopAnalyser();

        public string Analyse(CSharpCompilation compiledCode, string requirements)
        {
            throw new NotImplementedException();
        }

        public string Analyse(CSharpSyntaxTree syntaxTree, string requirements)
        {
            // check loop 5 times
            int result = genericLoopAnalyser.getLoopAmount(syntaxTree, requirements, 5);
            return result == 5 ? "is 5" : "not 5";
        }
    }
}
