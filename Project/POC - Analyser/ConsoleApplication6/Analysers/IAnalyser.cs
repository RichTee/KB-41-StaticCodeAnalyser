using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6.Analysers
{
    interface IAnalyser
    {
        string Analyse(CSharpCompilation compiledCode, string requirements);
        string Analyse(CSharpSyntaxTree syntaxTree, string requirements);

    }
}
