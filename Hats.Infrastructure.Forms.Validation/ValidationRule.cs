using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public class ValidationRule
    {
        public ValidationRule()
        {
        }

        public ValidationRule(object @object, ValidationType validationType, string message, object criteria = null, 
            object secondCriteria = null, Func<bool> action = null, IValidationRule customRule = null)
        {
            this.Object = @object;
            this.ValidationType = validationType;
            this.Criteria = criteria;
            this.SecondCriteria = secondCriteria;
            this.Message = message;
            this.CustomValidationAction = action;
            this.CustomRule = customRule;
        }

        public object Object { get; set; }
        public ValidationType ValidationType { get; set; }
        public object Criteria { get; set; }
        public object SecondCriteria { get; set; }
        public string Message { get; set; }
        public Func<bool> CustomValidationAction { get; set; }
        public IValidationRule CustomRule { get; set; }
    }
}
