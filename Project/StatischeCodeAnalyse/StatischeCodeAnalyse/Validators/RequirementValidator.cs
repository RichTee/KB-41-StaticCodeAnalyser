using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Validators
{
    class RequirementValidator : ValidatorInterface
    {
        public void IsRequired(string[] required)
        {
            throw new NotImplementedException();
        }

        public void IsRequired(Dictionary<string, string> required)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string unvalidated)
        {
            // TODO: Make it a JSON object and validate if the values within it are as expected

            return true;
        }
    }
}
