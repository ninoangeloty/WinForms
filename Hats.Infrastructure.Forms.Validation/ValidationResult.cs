using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public class ValidationResult
    {
        public ValidationResult(ValidationRule rule, bool success)
        {
            this.Rule = rule;
            this.Success = success;
        }

        public ValidationRule Rule { get; set; }
        public bool Success { get; set; }
    }
}
