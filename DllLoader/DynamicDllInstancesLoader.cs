// <copyright file="DynamicDllInstancesLoader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dllclass
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;

    public class DynamicDllInstancesLoader
    {
        public DynamicDllInstancesLoader()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            this.PathToDlls = config.GetSection("PathToDll")["path"];
        }

        public string PathToDlls { get; set; }

        public List<T> LoadInstances<T>()
        {
            string assemblyPath = this.PathToDlls;
            var listOfTypeInstances = new List<T>();

            if (!Directory.Exists(assemblyPath))
            {
                return listOfTypeInstances;
            }

            IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
            assemblyPath, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (string assemblyFile in assemblyFiles)
            {

                Assembly assembly = Assembly.LoadFrom(assemblyFile);
                foreach (Module md in assembly.GetModules(true))
                {
                    Console.WriteLine(md.ToString());
                }

                foreach (Type type in assembly.ExportedTypes)
                {
                    if (type.IsClass &&
                    typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        listOfTypeInstances.Add((T)this.GetImplementation(type));
                    }
                }
            }

            if (listOfTypeInstances.Count > 0)
            {
                listOfTypeInstances.RemoveAll(item => item == null);
            }

            return listOfTypeInstances;
        }

        private object GetImplementation(Type actualType)
        {
            if (actualType.IsClass)
            {
                return this.InstanceByReflection(actualType);
            }
            else
            {
                return null;
            }
        }

        private object InstanceByReflection(Type actualType)
        {
            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => this.GetImplementation(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);
            return implementation;
        }
    }
}