using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace StatischeCodeAnalyse.Services
{
    class ReceiverService
    {
        // Produces a dictionary with accepted named variables
        public Dictionary<string, string> ProcessInput(string[] args)
        {
            Dictionary<string, string> argDictionary = ArgToDictionary(args);

            return argDictionary;
        }

        // Transform received args to a key-value pair. Requires that sent args are in key-value pair format
        // Example input: testName=testVariable
        public Dictionary<string, string> ArgToDictionary(string[] args)
        {
            Dictionary<string, string> keyValueTable = new Dictionary<string, string>();

            foreach(string arg in args)
            {
                if (!IsNamed(arg))
                    continue;

                string[] split = arg.Split('=');
                keyValueTable.Add(split[0], split[1]);
            }

            return ValidateArgs(keyValueTable);
        }

        // Check if the received arg is of correct format to be a key-value pair.
        public bool IsNamed(string arg)
        {
            var searchRegex = new Regex("^(?<key>.*)=(?<value>.*)");

            return searchRegex.IsMatch(arg);
        }

        public Dictionary<string, string> ValidateArgs(Dictionary<string, string> argDictionary)
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

        public void ValidateType(string key, string val, Type type)
        {
            Type typeOfVal = val.GetType();

            if(typeOfVal != type)
            {
                throw new Exception(key + " has to be of type " + type);
            }

        }
    }
}