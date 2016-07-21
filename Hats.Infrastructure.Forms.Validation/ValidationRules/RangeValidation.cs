using Hats.Infrastructure.Forms.Validation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms.Validation.ValidationRules
{
    public class RangeValidation : IValidationRule
    {
        public IEnumerable<ValidationResult> Validate(ValidationRule rule)
        {
            if (rule.Object is TextBox)
            {
                yield return new ValidationResult(rule, ValidationHelper.Range(
                    decimal.Parse(ValidationHelper.GetValue(rule.Object, Members.Text).ToString()),
                    decimal.Parse(rule.Criteria.ToString()),
                    decimal.Parse(rule.SecondCriteria.ToString())));
            }
        }
    }
}
