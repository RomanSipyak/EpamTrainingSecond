namespace IOCcontainer.IOC.Return_Instance_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IOCcontainer.IOC.Instance_Logic;

    public class DiContainer
    {
        public readonly List<ServiceDescriptor> serviceDescriptors;

        public DiContainer( ref List<ServiceDescriptor> serviceDescriptors)
        {
            this.serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var desciptor = this.serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (desciptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} isn't registered");
            }

            if (desciptor.Implementation != null)
            {
                return desciptor.Implementation;
            }

            var actualType = desciptor.ImplementationType ?? desciptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }

            object implementation = this.InstanceByreflection(actualType);

            if (desciptor.Lifetime == ServiceLifeTime.Singleton)
            {
                desciptor.Implementation = implementation;
            }

            return implementation;
        }

        private object InstanceByreflection(Type actualType)
        {
            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => this.GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);
            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
