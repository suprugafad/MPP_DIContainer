using System;

namespace DIContainer.Container
{
    public interface IDependencyContainer
    {
        T Resolve<T>();
    
        object Resolve(Type dependencyType);
    }
}