namespace DIContainer.Dependency
{
    public class SingletonDependencyWrapper
    {
        public DependencyDefinition Definition { get; }

        public object Instance { get; }

        public SingletonDependencyWrapper(DependencyDefinition definition, object instance)
        {
            Definition = definition;
            Instance = instance;
        }
    }
}