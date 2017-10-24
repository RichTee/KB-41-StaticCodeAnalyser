using System.Collections.Generic;
using StatischeCodeAnalyse.Services;
using StatischeCodeAnalyse.Services.Analyzer;
using System;
using Newtonsoft.Json;

namespace StatischeCodeAnalyse
{
    class Program
    {
        private static ReceiverService receiverService = new ReceiverService();
        private static RequirementService requirementService = new RequirementService();
        private static AnalyseService analyseService = new AnalyseService();
        private static FileService fileService = new FileService();
        private static ResponseService responseService = new ResponseService();

        public static void Main(string[] args)
        {
            try
            {
                // Process the named input
                Dictionary<string, string> argDictionary = receiverService.ProcessInput(args);
                //string path = fileService.CreateCsFile("fileName", argDictionary["code"], argDictionary["savelocation"]);

                // Make some kind of processor that returns the path of a file.
                //if (string.IsNullOrEmpty(path))
                //    throw new Exception("Could not create file");

                // Process the requirements
                string[] requirements = requirementService.ProcessRequirements(argDictionary["requirements"]);

                // Compile the code and try to analyze for requirements
                string[] analysis = analyseService.CompileAndAnalyze(argDictionary["code"], requirements);
                Console.WriteLine(JsonConvert.SerializeObject(responseService.Success(JsonConvert.SerializeObject(analysis))));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                Console.WriteLine(JsonConvert.SerializeObject(responseService.CustomError(Enums.StatusCode.EXCEPTION, exc.Message)));
            }

            Console.Read();
        }
    }
}