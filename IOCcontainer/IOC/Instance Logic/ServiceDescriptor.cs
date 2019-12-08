// <copyright file="ServiceDescriptor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IOCcontainer.IOC.Instance_Logic
{
    using System;

    public enum ServiceLifeTime
    {
        Singleton,
        Transient
    }

    public class ServiceDescriptor
    {
        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public object Implementation { get; internal set; }

        public ServiceLifeTime Lifetime { get; }

        public ServiceDescriptor(object implementation, ServiceLifeTime lifetime)
        {
            this.ServiceType = implementation.GetType();
            this.Implementation = implementation;
            this.Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifeTime lifetime)
        {
            this.ServiceType = serviceType;
            this.Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifeTime lifetime)
        {
            this.ServiceType = serviceType;
            this.Lifetime = lifetime;
            this.ImplementationType = implementationType;
        }
    }
}
