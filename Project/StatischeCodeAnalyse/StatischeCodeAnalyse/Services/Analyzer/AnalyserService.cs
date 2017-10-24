using Microsoft.CodeAnalysis.CSharp;
using StatischeCodeAnalyse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Services.Analyzer
{
    class AnalyserService
    {
        private CompilerService compilerService = new CompilerService();

        public List<DiagnosticReport> CompileAndAnalyze(string sourceCode, string[] requirements)
        {
            List<DiagnosticReport> compiledDiagnostics = compilerService.CompileAndGetDiagnostic(sourceCode);
            // string[] analyzedResult = Analyze(sourceCode, requirements);
            return compiledDiagnostics;
        }

        // Do our own static code analysis here, the code within is just a setup and can be safely modified.
        private string[] Analyze(string sourceCode, string[] requirements)
        {
            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpsyntaxtree?view=codeanalysiscs-2.3.1
            var parsedSyntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            // TODO: Analyze for requirements, see POC document and POC project for more information.
            string[] analyzedResult = new String[1];

            return analyzedResult;
        }
    }
}
