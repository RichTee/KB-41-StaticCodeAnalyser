using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6.Models
{
    class RequirementOutput
    {
        [JsonProperty]
        private string name { get; set; }
        [JsonProperty]
        private string description { get; set; }
        [JsonProperty]
        private bool status { get; set; }
        [JsonProperty]
        private string additional_information { get; set; }

        public RequirementOutput() { }

        public RequirementOutput(string name, string description, bool status, string additional_information)
        {
            this.name = name;
            this.description = description;
            this.status = status;
            this.additional_information = additional_information;
        }
    }
}
