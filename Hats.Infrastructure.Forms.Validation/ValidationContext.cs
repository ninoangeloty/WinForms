using Hats.Infrastructure.Forms.Validation.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public class ValidationContext
    {
        #region Singleton Implementation

        private static object myLock = new object();
        private static volatile ValidationContext instance = null;

        private ValidationContext()
        {
        }

        public static ValidationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (myLock)
                    {
                        if (instance == null)
                        {
                            instance = new ValidationContext();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion

        public void Clear()
        {
            this.Rules.Clear();
            this.Result = null;
        }

        public void Initialize()
        {            
            this.Rules = new List<ValidationRule>();
            this.Result = null;
        }

        public void AddRule(Func<bool> action, string message)
        {
            this.Rules.Add(new ValidationRule(null, ValidationType.CustomAction, message, action: action));
        }

        public void AddRule(object @object, ValidationType validationType, string message, object criteria = null, object secondCriteria = null, Func<bool> action = null, IValidationRule customRule = null)
        {
            this.Rules.Add(new ValidationRule(@object, validationType, message, criteria, secondCriteria, action, customRule));
        }

        public void Validate()
        {
            this.Result = this.Execute();
        }

        private IEnumerable<ValidationResult> Execute()
        {
            var result = new List<ValidationResult>();

            foreach (var rule in this.Rules)
            {
                if (rule.ValidationType == ValidationType.Required)
                {
                    result.AddRange(new RequiredValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.StringLength)
                {
                    result.AddRange(new StringLengthValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.RegularExpression)
                {
                    result.AddRange(new RegularExpressionValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.Range)
                {
                    result.AddRange(new RangeValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.Numeric)
                {
                    result.AddRange(new NumericValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.CustomAction)
                {
                    result.AddRange(new CustomActionValidation().Validate(rule));
                }
                else if (rule.ValidationType == ValidationType.Custom)
                {
                    result.AddRange(GetValidationResultFromCustomRule(rule));
                }
            }

            return result;
        }

        private static IEnumerable<ValidationResult> GetValidationResultFromCustomRule(ValidationRule rule)
        {
            return rule.CustomRule.Validate(rule);
        }

        public List<ValidationRule> Rules { get; private set; }

        public IEnumerable<ValidationResult> Result { get; private set; }
    }
}
