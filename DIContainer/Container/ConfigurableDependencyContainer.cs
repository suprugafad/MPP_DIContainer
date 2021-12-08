using System;
using System.Collections.Generic;
using System.Reflection;
using DIContainer.Configuration;
using DIContainer.Dependency;
using DIContainer.Exception;

namespace DIContainer.Container
{
    public class ConfigurableDependencyContainer : IDependencyContainer
    {
        private const string NullDependencyType = "Dependency of type is null";
        private const string NullImplType = "Implementation of type is null";

        private readonly List<DependencyDefinition> _definitions;
        private readonly Dictionary<Type, SingletonDependencyWrapper> _singletons = new();
        private readonly object _lock = new();

        public ConfigurableDependencyContainer(ContainerConfiguration config)
        {
            _definitions = config.DependencyDefinitions;
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public object Resolve(Type dependencyType)
        {
            var definition = _definitions.Find(definition => definition.DependencyType == dependencyType) ??
                             throw new DependencyMissingException(NullDependencyType + dependencyType.Name);
            if (definition.Scope == DependencyScope.Prototype)
            {
                return CreateInstance(definition.ImplementationType);
            }

            lock (_lock)
            {
                object instance;
                if (_singletons.TryGetValue(definition.DependencyType, out var wrapper))
                {
                    instance = wrapper.Instance;
                }
                else
                {
                    instance = CreateInstance(definition.ImplementationType);
                    _singletons.Add(dependencyType, new SingletonDependencyWrapper(definition, instance));
                }

                return instance;
            }
        }

        private object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            foreach (var constructor in constructors)
            {
                var constructorParams = constructor.GetParameters();
                var generatedParams = new List<dynamic>();
                foreach (var parameterInfo in constructorParams)
                {
                    dynamic parameter;
                    if (parameterInfo.ParameterType.IsInterface)
                    {
                        parameter = Resolve(parameterInfo.ParameterType);
                    }
                    else
                    {
                        break;
                    }

                    generatedParams.Add(parameter);
                }

                return constructor.Invoke(generatedParams.ToArray());
            }

            throw new DependencyInstantiationException(NullImplType + type.Name);
        }
    }
}