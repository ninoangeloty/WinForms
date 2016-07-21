using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public class CustomActionValidation
    {
        public IEnumerable<ValidationResult> Validate(ValidationRule rule)
        {
            yield return new ValidationResult(rule, rule.CustomValidationAction.Invoke());
        }
    }
}
