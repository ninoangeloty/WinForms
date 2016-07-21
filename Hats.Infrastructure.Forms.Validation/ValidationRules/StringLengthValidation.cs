using Hats.Infrastructure.Forms.Validation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms.Validation.ValidationRules
{
    public class StringLengthValidation : IValidationRule
    {
        public IEnumerable<ValidationResult> Validate(ValidationRule rule)
        {
            if (rule.Object is TextBox)
            {
                yield return new ValidationResult(rule, ValidationHelper.StringLength(ValidationHelper.GetValue(rule.Object, Members.Text).ToString(), (int)rule.Criteria));
            }
        }
    }
}
