using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Cecil
{
    class Program
    {
        string myString = "This is a string";
        int myInt = 5;
        static void Main(string[] args)
        {
            string myfile = "../../Program.dll";
            PrintTypes(myfile);
            Console.Read();
        }

        public static void PrintTypes(string fileName)
        {
            ModuleDefinition module = ModuleDefinition.ReadModule(fileName);
            Console.WriteLine(module);
            foreach (TypeDefinition type in module.Types)
            {
                if (!type.IsPublic)
                    continue;

                Console.WriteLine(type.FullName);
            }
        }
    }
}
