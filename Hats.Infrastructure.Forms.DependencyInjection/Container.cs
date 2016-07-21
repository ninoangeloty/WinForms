using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hats.Infrastructure.Forms.DependencyInjection
{
    public class Container
    {
        #region Singleton Implementation

        private static object myLock = new object();
        private static volatile Container instance = null; // 'volatile' is unnecessary in .NET 2.0 and later

        private Container()
        {
        }

        public static Container Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (myLock)
                    {
                        if (instance == null)
                        {
                            instance = new Container();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion

        public object Resolve(Type type)
        {
            if (!this.ObjectCollection.ContainsKey(type))
            {
                throw new ArgumentException("Type not registered.");
            }

            var manager = new InstanceManager();

            ContainerObjectDescriptor meta;
            this.ObjectCollection.TryGetValue(type, out meta);

            return manager.GetInstance(meta);
        }

        public void RegisterType<TFrom, TTo>()
            where TFrom : class
            where TTo : class
        {
            this.Register(typeof(TFrom), typeof(TTo), null, LifetimePolicy.Default);
        }

        public void RegisterInstance<TFrom, TTo>()
            where TFrom : class
            where TTo : class
        {
            this.Register(typeof(TFrom), typeof(TTo), null, LifetimePolicy.Singleton);
        }

        public void RegisterInstance<TFrom>(object obj)
            where TFrom : class
        {
            this.Register(typeof(TFrom), obj.GetType(), obj, LifetimePolicy.Singleton);
        }

        public void Remove<T>()
            where T : class
        {
            if (!this.ObjectCollection.ContainsKey(typeof(T)))
            {
                throw new ArgumentException("Type not registered.");
            }

            this.ObjectCollection.Remove(typeof(T));
        }

        private void Register(Type from, Type to, object instance, LifetimePolicy lifetime)
        {
            this.ObjectCollection.Add(from, new ContainerObjectDescriptor(from, to, instance, lifetime));
        }

        private Dictionary<Type, ContainerObjectDescriptor> _objectCollection;
        private Dictionary<Type, ContainerObjectDescriptor> ObjectCollection 
        { 
            get
            {
                return (_objectCollection != null ? _objectCollection : 
                    _objectCollection = new Dictionary<Type, ContainerObjectDescriptor>());
            }

            set
            {
                _objectCollection = value;
            }
        }
    }
}
