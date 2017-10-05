using Newtonsoft.Json;
using StatischeCodeAnalyse.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Services
{
    class RequirementService
    {
        private RequirementValidator requirementValidator = new RequirementValidator();

        // Produces a dictionary with accepted named variables
        public string[] ProcessRequirements(string requirements)
        {
            dynamic json = JsonConvert.DeserializeObject(requirements);
            // TODO: Process the Requirements for validity (expected format) and make it a variable that can be used by the analyzer
            // Does not have to be string array
            return new String[1];
        }
    }
}
