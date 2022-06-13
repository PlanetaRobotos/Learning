using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace Infrastructure
{
    public class DependenciesCollection
    {
        private List<Dependency> dependencies = new();
        private Dictionary<Type, object> singletons = new();
        
        public object Get(Type type)
        {
            if (!dependencies.Contains(dependencies.FirstOrDefault(d=>d.Type == type)))
            {
                throw new ArgumentException("Type is not a dependency: " + type.FullName);
            }

            var dependency = dependencies.FirstOrDefault(d=>d.Type == type);
            if (dependency.IsSingleton)
            {
                if (!singletons.ContainsKey(type))
                {
                    singletons.Add(type, dependency.Factory());
                }
                return singletons[type];
            }
            else
            {
                return dependency.Factory();
            }
        }

        public void Add(Dependency dependency) => dependencies.Add(dependency);
        
        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }
    }
}