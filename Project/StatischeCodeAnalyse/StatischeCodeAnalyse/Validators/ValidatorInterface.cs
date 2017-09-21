using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatischeCodeAnalyse.Validators
{
    interface ValidatorInterface
    {
        bool Validate(string unvalidated);
    }
}
