namespace IOCcontainer.IOC.Instance_Logic
{
    using System.Collections.Generic;
    using IOCcontainer.IOC.Return_Instance_Logic;

    public class ServiceCollection
    {
        private List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();
        private DiContainer containerOfInstances;

        public ServiceCollection()
        {
            this.containerOfInstances = new DiContainer(ref this.serviceDescriptors); 
        }

        public void RegisterSingleton<TService>()
        {
            this.serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            this.serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            this.serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            this.serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            this.serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
        }

        public T GetService<T>()
        {
            return (T)this.containerOfInstances.GetService(typeof(T));
        }
    }
}
