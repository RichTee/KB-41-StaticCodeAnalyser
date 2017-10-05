using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Services.Analyzer
{
    class AnalyseService
    {
        private CompilerService compilerService = new CompilerService();

        public string[] CompileAndAnalyze(string sourceCode, string[] requirements)
        {
            string[] compiledDiagnostics = compilerService.CompileAndGetDiagnostic(sourceCode);
            string[] analyzedResult = Analyze(sourceCode, requirements);
            return new String[1];
        }

        private string[] Analyze(string sourceCode, string[] requirements)
        {
            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpsyntaxtree?view=codeanalysiscs-2.3.1
            var parsedSyntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            // TODO: Analyze for requirements
            string[] analyzedResult = new String[1];

            return analyzedResult;
        }
    }
}
