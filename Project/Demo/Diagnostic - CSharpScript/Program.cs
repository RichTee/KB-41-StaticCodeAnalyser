using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Microsoft.CodeAnalysis.Emit;
using System.IO;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        private static void test()
        {
            using (var loader = new InteractiveAssemblyLoader())
            {
                var source = @"
                                public class Output { public statitc void Main() { } }
                            ";
                // Shows namespace declaration as an error
                var script = CSharpScript.Create(source, assemblyLoader: loader);
                Compilation compilation = script.GetCompilation();

                using (var ms = new MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);

                        foreach (var diag in failures)
                        {
                            Console.Error.WriteLine("{0}: {1}", diag.Id, diag.GetMessage());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Success");
                    }
                }
                Console.Read();
            }
        }
    }
}
