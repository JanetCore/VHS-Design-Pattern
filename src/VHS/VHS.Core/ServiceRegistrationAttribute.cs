using System;

namespace VHS.Core
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ServiceRegistrationAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }

        public ServiceRegistrationAttribute(ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            Lifetime = lifetime;
        }
    }
}