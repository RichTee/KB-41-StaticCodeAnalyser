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
        private static ResponseService responseService = new ResponseService();

        public static void Main(string[] args)
        {
            try
            {
                Dictionary<string, string> argDictionary = receiverService.ProcessInput(args);
                //string path = fileService.CreateCsFile("fileName", argDictionary["code"], argDictionary["savelocation"]);

                // Make some kind of processor that returns the path of a file.
                //if (string.IsNullOrEmpty(path))
                //    throw new Exception("Could not create file");
            }
            catch (Exception exc)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(responseService.CustomError(Enums.StatusCode.EXCEPTION, exc.Message)));
            }

            Console.Read();
        }
    }
}