using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public static class ValidationHelper
    {
        public static bool StringNullOrWhitespace(string @string)
        {
            return string.IsNullOrWhiteSpace(@string);
        }

        public static bool StringLength(string @string, int length)
        {
            return @string.Length <= length;
        }

        public static bool NotNull(object @object)
        {
            return @object != null;
        }

        public static bool IsNumeric(object @object)
        {
            decimal @out;
            return decimal.TryParse(@object.ToString(), out @out);
        }

        public static bool Range(decimal value, decimal min, decimal max)
        {
            return value >= min && value <= max;
        }

        public static object GetValue(object @object, string member)
        {
            return @object.GetType().GetProperty(member).GetValue(@object, null);
        }
    }
}
