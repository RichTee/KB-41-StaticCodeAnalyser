namespace StatischeCodeAnalyse.Validators
{
    class ReceiverValidator : ValidatorInterface
    {
        public bool Validate(string unvalidated)
        {
            switch (unvalidated)
            {
                case "code":
                case "requirements":
                    return true;
                default:
                    return false;
            }
        }
    }
}
