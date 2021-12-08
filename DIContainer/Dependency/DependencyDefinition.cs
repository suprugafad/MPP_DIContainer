using System;

namespace DIContainer.Dependency
{
    public class DependencyDefinition
    {
        public Type DependencyType { get; }
        public Type ImplementationType { get; }
        public DependencyScope Scope { get; }

        public DependencyDefinition(Type dependencyType, Type implementationType, DependencyScope scope)
        {
            DependencyType = dependencyType;
            ImplementationType = implementationType;
            Scope = scope;
        }
    }
}