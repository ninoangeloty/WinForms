using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation.ValidationRules
{
    public class CustomActionValidation : IValidationRule
    {
        public IEnumerable<ValidationResult> Validate(ValidationRule rule)
        {
            if (rule.ValidationType == ValidationType.CustomAction)
            {
                yield return new ValidationResult(rule, rule.CustomValidationAction.Invoke());
            }
        }
    }
}
