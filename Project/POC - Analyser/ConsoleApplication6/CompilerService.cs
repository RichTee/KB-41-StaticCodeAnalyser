using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class CompilerService
    {
        private static MetadataReference[] references = new MetadataReference[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
        };


        private static readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);



        public CSharpSyntaxTree CreateSyntaxTree(string source)
        {
            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpsyntaxtree?view=codeanalysiscs-2.3.1
            return (CSharpSyntaxTree) CSharpSyntaxTree.ParseText(source);
        }

        public CSharpCompilation CreateCompilation(string source)
        {
            var parsedSyntaxTree = CreateSyntaxTree(source);

            // https://docs.microsoft.com/en-us/roslyn-dotnet-api/api/microsoft.codeanalysis.csharp.csharpcompilation?view=codeanalysiscs-2.3.1
            var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), new SyntaxTree[] { parsedSyntaxTree }, references, DefaultCompilationOptions);

            return compilation;
        }
    }
}
