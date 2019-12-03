using IOCcontainer.IOC.Instance_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCcontainer.IOC.Return_Instance_Logic
{
    public class DiContainer
    {
        public readonly List<ServiceDescriptor> _serviceDescriptors;

        public DiContainer( ref List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var desciptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

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

            object implementation = InstanceByreflection(actualType);

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
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);
            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
