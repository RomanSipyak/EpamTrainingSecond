using IOCcontainer.IOC.Return_Instance_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCcontainer.IOC.Instance_Logic
{
    public class ServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
        private DiContainer containerOfInstances;
        public ServiceCollection()
        {
            containerOfInstances = new DiContainer(ref _serviceDescriptors); 
        }
        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
        }

        public T GetService<T>()
        {
            return (T)containerOfInstances.GetService(typeof(T));
        }
    }
}
