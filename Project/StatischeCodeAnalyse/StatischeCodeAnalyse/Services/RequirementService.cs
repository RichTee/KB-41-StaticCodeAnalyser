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
            string[] analyserRules = null;

            return analyserRules;
        }
    }
}
