using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hats.Infrastructure.Forms.Validation
{
    public static class TextboxExtensions
    {
        public static void Required(this TextBox textbox, string message)
        {
            ValidationContext.Instance.AddRule(textbox, ValidationType.Required, message);
        }

        public static void StringLength(this TextBox textbox, int length, string message)
        {
            ValidationContext.Instance.AddRule(textbox, ValidationType.StringLength, message, length);
        }

        public static void RegularExpression(this TextBox textbox, string regex, string message)
        {
            ValidationContext.Instance.AddRule(textbox, ValidationType.RegularExpression, message);
        }

        public static void Range(this TextBox textbox, decimal min, decimal max, string message)
        {
            ValidationContext.Instance.AddRule(textbox, ValidationType.RegularExpression, message, min, max);
        }

        public static void Numeric(this TextBox textbox, string message)
        {
            ValidationContext.Instance.AddRule(textbox, ValidationType.Numeric, message);
        }
    }
}
