using StatischeCodeAnalyse.Validators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace StatischeCodeAnalyse.Services
{
    class ReceiverService
    {
        private ReceiverValidator receiverValidator = new ReceiverValidator();

        // Produces a dictionary with accepted named variables
        public Dictionary<string, string> ProcessInput(string[] args)
        {
            Dictionary<string, string> argDictionary = ArgToDictionary(args);
            receiverValidator.IsRequired(argDictionary);
            return argDictionary;
        }

        // Transform received args to a key-value pair. Requires that sent args are in key-value pair format
        // Example input: testName=testVariable
        private Dictionary<string, string> ArgToDictionary(string[] args)
        {
            Dictionary<string, string> keyValueTable = new Dictionary<string, string>();

            foreach(string arg in args)
            {
                if (!IsNamed(arg))
                    continue;

                string[] split = arg.Split('=');

                if (!receiverValidator.Validate(split[0]))
                    continue;

                keyValueTable.Add(split[0], split[1]);
            }
            
			//set default save location if not exist
			if (!keyValueTable.ContainsKey("savelocation"))
                keyValueTable.Add("savelocation", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/tmp");

            return keyValueTable;
        }

        // Check if the received arg is of correct format to be a key-value pair.
        private bool IsNamed(string arg)
        {
            var searchRegex = new Regex("^(?<key>.*)=(?<value>.*)");

            return searchRegex.IsMatch(arg);
        }
    }
}