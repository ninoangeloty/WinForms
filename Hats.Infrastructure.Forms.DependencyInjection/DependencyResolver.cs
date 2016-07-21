using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hats.Infrastructure.Forms.DependencyInjection
{
    public class DependencyResolver
    {
        public void EvaluateDependency(object @this)
        {
            Origin = @this;

            var fields = GetValidFields(@this.GetType().GetProperties());

            ResolveProperties(fields.ToArray());
        }

        private void ResolveProperties(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var type = property.PropertyType.UnderlyingSystemType;
                var instance = Infrastructure.Forms.DependencyInjection.Container.Instance.Resolve(type);

                property.SetValue(Origin, instance, null);
            }
        }

        private IEnumerable<PropertyInfo> GetValidFields(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(DependencyInjectionAttribute), false).FirstOrDefault();

                if (attribute != null)
                {
                    yield return property;
                }
            }
        }

        private object Origin { get; set; }
    }
}
