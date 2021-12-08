using DIContainer.Configuration;
using DIContainer.Container;
using DIContainer.Dependency;
using DITests.repository;
using DITests.repository.impl;
using DITests.service;
using DITests.service.impl;

namespace ConsoleApp
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var config = new ContainerConfiguration();
            config.Register<IRepository, Repository>(DependencyScope.Prototype);
            config.Register<IService, Service>();
            
            IDependencyContainer container = new ConfigurableDependencyContainer(config);
            
            var repository1 = (IRepository) container.Resolve(typeof(IRepository));
            var repository2 = (IRepository) container.Resolve(typeof(IRepository));
            
            var service1 = container.Resolve<IService>();
            var service2 = container.Resolve<IService>();

            return 0;
        }
    }
}