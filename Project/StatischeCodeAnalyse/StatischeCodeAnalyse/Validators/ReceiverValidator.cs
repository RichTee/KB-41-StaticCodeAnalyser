using System;
using System.Collections.Generic;
using StatischeCodeAnalyse.Exceptions;

namespace StatischeCodeAnalyse.Validators
{
    class ReceiverValidator : ValidatorInterface
    {
        private const string requirement_code = "code";
        private const string requirement_requirements = "requirements";
        private const string requirement_savelocation = "savelocation";

        public void IsRequired(string[] required)
        {
            throw new NotImplementedException();
        }

        public void IsRequired(Dictionary<string, string> required)
        {
            List<string> notFoundRequirements = new List<string>();

            if (!required.ContainsKey(requirement_code))
                notFoundRequirements.Add(requirement_code + " input field is required");

            if (!required.ContainsKey(requirement_requirements))
                notFoundRequirements.Add(requirement_requirements + " input field is required");

            if (!required.ContainsKey(requirement_savelocation))
                notFoundRequirements.Add(requirement_savelocation + " input field is required");

            if (notFoundRequirements.Count != 0)
                throw new InputException(String.Join(", ", notFoundRequirements.ToArray()));
        }

        public bool Validate(string unvalidated)
        {
            switch (unvalidated)
            {
                case requirement_code:
                case requirement_requirements:
                case requirement_savelocation:
                    return true;
                default:
                    return false;
            }
        }
    }
}
