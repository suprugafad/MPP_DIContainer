using System;
using System.Collections.Generic;
using DIContainer.Dependency;

namespace DIContainer.Configuration
{
    public class ContainerConfiguration
    {
        public List<DependencyDefinition> DependencyDefinitions { get; } = new();

        public ContainerConfiguration()
        {
        }

        public void Register<TDep, TImpl>(DependencyScope scope = DependencyScope.Singleton) where TImpl : TDep
        {
            DependencyDefinitions.Add(new DependencyDefinition(typeof(TDep), typeof(TImpl), scope));
        }
    }
}