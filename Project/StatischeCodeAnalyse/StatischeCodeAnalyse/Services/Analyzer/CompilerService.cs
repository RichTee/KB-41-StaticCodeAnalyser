using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatischeCodeAnalyse.Models;

namespace StatischeCodeAnalyse.Services.Analyzer
{
    class CompilerService
    {
        private MetadataReference[] references = new MetadataReference[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
        };


        private readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);

        private EmitResult Compile(string sourceCode)
        {
            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpsyntaxtree?view=codeanalysiscs-2.3.1
            var parsedSyntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpcompilation?view=codeanalysiscs-2.3.1
            var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), new SyntaxTree[] { parsedSyntaxTree }, references, DefaultCompilationOptions);

            using (var ms = new MemoryStream())
            {
                return compilation.Emit(ms);
            }
        }

        private List<DiagnosticReport> GetCompilerDiagnostic(EmitResult result)
        {
            List<DiagnosticReport> diagnostics = new List<DiagnosticReport>();

            if (!result.Success)
            {
                // Only show errors
                //IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
                IEnumerable<Diagnostic> failures = result.Diagnostics;

                foreach (var diag in failures)
                {
                    diagnostics.Add(new DiagnosticReport(diag.GetMessage(), diag.Severity.ToString(), diag.Id));
                }
            }
            else
            {
                Console.WriteLine("No Diagnostics from Compiled Result");
            }

            return diagnostics;
        } 

        public List<DiagnosticReport> CompileAndGetDiagnostic(string sourceCode)
        {
            EmitResult compiledResult = Compile(sourceCode);
            List<DiagnosticReport> diagnostic = GetCompilerDiagnostic(compiledResult);
            return diagnostic;
        }
    }
}
