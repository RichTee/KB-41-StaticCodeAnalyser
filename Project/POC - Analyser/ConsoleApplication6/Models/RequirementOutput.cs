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
        private string name;
        [JsonProperty]
        private string description;
        [JsonProperty]
        private bool status;
        [JsonProperty]
        private string additional_information;

        public RequirementOutput() { }

        public RequirementOutput(string name, string description, bool status, string additional_information)
        {
            this.name = name;
            this.description = description;
            this.status = status;
            this.additional_information = additional_information;
        }

        public string GetName()
        {
            return name;
        }

        public bool SetName(string name)
        {
            this.name = name;
            return true;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool SetDescription(string description)
        {
            this.description = description;
            return true;
        }

        public bool GetStatus()
        {
            return status;
        }

        public bool SetStatus(bool status)
        {
            this.status = status;
            return true;
        }

        public string GetAdditionalInformation()
        {
            return additional_information;
        }

        public bool SetAdditionalInformation(string additional_information)
        {
            this.additional_information = additional_information;
            return true;
        }
    }
}
