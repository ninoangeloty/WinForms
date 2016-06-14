using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infrastructure.Forms.DependencyInjection
{
    public class BaseForm : Form
    {
        public BaseForm() : base() 
        {
            this.EvaluateDependency();
        }

        public void EvaluateDependency()
        {
            var fields = this.GetValidFields(this.GetType().GetProperties());

            this.ResolveProperties(fields.ToArray());
        }

        private void ResolveProperties(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var type = property.PropertyType.UnderlyingSystemType;
                var instance = Infrastructure.Forms.DependencyInjection.Container.Instance.Resolve(type);

                property.SetValue(this, instance);
            }
        }

        private IEnumerable<PropertyInfo> GetValidFields(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DependencyInjectionAttribute>();

                if (attribute != null)
                {
                    yield return property;
                }                
            }
        }
    }
}
