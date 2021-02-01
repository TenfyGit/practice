using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class MapToAttribute:Attribute
    {
        public Type ServiceType { get; }
        public Lifetime Lifetime { get; }
        public MapToAttribute(Type serviceType,Lifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }
    }
}
