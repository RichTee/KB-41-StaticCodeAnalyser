using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Services
{
    class FileService
    {

        // Create a csharp file in given path with given content and filename
        public string CreateCsFile(string fileName, string content, string path)
        {
            string fullPath = path + "/" + fileName + ".cs";

            using (FileStream fs = File.Create(fullPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            if (!File.Exists(fileName))
                fullPath = "";

            return fullPath;
        }
    }
}
