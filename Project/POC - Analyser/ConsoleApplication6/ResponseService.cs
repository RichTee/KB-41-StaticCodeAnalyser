using ConsoleApplication6.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class ResponseService
    {
        public string CreateRequirementOutput(string name, string description, bool status, string additional_information)
        {
            RequirementOutput requirementOutput = new RequirementOutput(name, description, status, additional_information);
            return JsonConvert.SerializeObject(requirementOutput);
        }
    }
}
