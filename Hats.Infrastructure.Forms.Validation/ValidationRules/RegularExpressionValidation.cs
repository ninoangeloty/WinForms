using Hats.Infrastructure.Forms.Validation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms.Validation.ValidationRules
{
    public class RegularExpressionValidation : IValidationRule
    {
        public IEnumerable<ValidationResult> Validate(ValidationRule rule)
        {
            if (rule.Object is TextBox)
            {
                var regex = new System.Text.RegularExpressions.Regex(rule.Criteria.ToString());
                yield return new ValidationResult(rule, regex.IsMatch(ValidationHelper.GetValue(rule.Object, Members.Text).ToString()));
            }
        }
    }
}
