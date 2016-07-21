using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Data.Mapper
{
    internal static class SqlDataMapperHelper
    {
        public static string GetColumn(PropertyInfo property)
        {
            var columnAttribute = property.GetCustomAttributes(typeof(ColumnNameAttribute), false).FirstOrDefault();

            if (columnAttribute != null)
            {
                return ((ColumnNameAttribute)columnAttribute).Column;
            }

            return property.Name;
        }
    }
}
