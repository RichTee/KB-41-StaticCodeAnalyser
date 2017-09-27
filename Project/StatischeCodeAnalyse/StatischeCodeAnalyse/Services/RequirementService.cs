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
        private RuleService ruleService = new RuleService();

        // Produces a dictionary with accepted named variables
        public string[] ProcessRequirements(string requirements)
        {
            dynamic json = JsonConvert.DeserializeObject(requirements);
            string[] analyserRules = null;

            foreach (var requirement in json.objectList)
            {
                if (!requirementValidator.Validate(requirements))
                {
                    // Throw Exception
                }

                ruleService.createRule(requirement);
            }

            return analyserRules;
        }
    }
}
