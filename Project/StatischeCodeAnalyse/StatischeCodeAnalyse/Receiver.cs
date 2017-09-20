using StatischeCodeAnalyse.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StatischeCodeAnalyse
{
    class Receiver
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> argDictionary = ArgToDictionary(args);
            Debug.WriteLine(argDictionary["testName"]);
            FileService fileService = new FileService();
            fileService.CreateCsFile("fileName", "codeContent", "D:/tmp");
        }

        // Transform received args to a key-value pair. Requires that sent args are in key-value pair format
        // Example input: testName=testVariable
        public static Dictionary<string, string> ArgToDictionary(string[] args)
        {
            Dictionary<string, string> keyValueTable = new Dictionary<string, string>();

            foreach(string arg in args)
            {
                if (!IsNamed(arg))
                    continue;

                string[] split = arg.Split('=');
                keyValueTable.Add(split[0], split[1]);
            }

            return keyValueTable;
        }

        // Check if the received arg is of correct format to be a key-value pair.
        public static Boolean IsNamed(string arg)
        {
            var searchRegex = new Regex("^(?<key>.*)=(?<value>.*)");

            return searchRegex.IsMatch(arg);
        }
    }
}