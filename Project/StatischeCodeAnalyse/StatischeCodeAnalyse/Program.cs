using System.Collections.Generic;
using StatischeCodeAnalyse.Services;
using System.Diagnostics;
using System;

namespace StatischeCodeAnalyse
{
    class Program
    {
        private static ReceiverService receiverService = new ReceiverService();
        private static FileService fileService = new FileService();

        public static void Main(string[] args)
        {
            Dictionary<string, string> argDictionary = receiverService.ProcessInput(args);
            string path = fileService.CreateCsFile("fileName", "codeContent", "D:/tmp");

            // Make some kind of processor that returns the path of a file.
            if (string.IsNullOrEmpty(path))
                throw new Exception("Could not create file");

        }
    }
}