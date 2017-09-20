using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Mono.Options;


namespace StatischeCodeAnalyse
{
    class Receiver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Amount of arguments: " + args.Length);

            foreach(string a in args) 
            {
                Console.WriteLine(a);
            }
        }
    }
}