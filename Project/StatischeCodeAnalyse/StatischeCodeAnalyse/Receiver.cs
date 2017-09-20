﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using StatischeCodeAnalyse.Services;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StatischeCodeAnalyse
{
    class Receiver
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> argDictionary = ArgToDictionary(args);
            argDictionary = ValidateArgs(argDictionary);

            foreach (string val in argDictionary.Values)
            {
                Debug.WriteLine(val);
            }

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

        public static Dictionary<string, string> ValidateArgs(Dictionary<string, string> argDictionary)
        {
            Dictionary<string, string> validatedDictionary = new Dictionary<string, string>();
            try
            {
                ValidateType("code", argDictionary["code"], typeof(string));
                ValidateType("requirements", argDictionary["requirements"], typeof(string));
                validatedDictionary.Add("code", argDictionary["code"]);
                validatedDictionary.Add("requirements", argDictionary["requirements"]);
            }
            catch(Exception e)
            {
                Debug.Write(e);
            }

            return validatedDictionary;
        }

        public static void ValidateType(string key, string val, Type type)
        {
            Type typeOfVal = val.GetType();
            if(typeOfVal != type)
            {
                throw new Exception(key + " has to be of type " + type);
            }

        }
    }
}