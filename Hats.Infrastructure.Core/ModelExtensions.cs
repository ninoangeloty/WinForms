using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hats.Infrastructure.Core
{
    public static class ModelExtensions
    {
        public static string GetPropertyName<T>(this T @this, Expression<Func<T, object>> expression)
        {
            if (expression.Body.GetType() == typeof(UnaryExpression))
            {
                var operand = expression.Body.GetType().GetProperty("Operand").GetValue(expression.Body, null);
                var memberValue = operand.GetType().GetProperty("Member").GetValue(operand, null);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue, null).ToString();
            }
            else
            {
                var memberValue = expression.Body.GetType().GetProperty("Member").GetValue(expression.Body, null);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue, null).ToString();
            }
        }
    }
}
