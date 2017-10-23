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
            return genericLoopAnalyser.IsLoopingAmount(syntaxTree, requirements, 5);
        }
    }
}
