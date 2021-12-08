using DIContainer.Configuration;
using DIContainer.Container;
using DIContainer.Dependency;
using DITests.repository;
using DITests.repository.impl;
using DITests.service;
using DITests.service.impl;
using NUnit.Framework;

namespace DITests
{
    public class DependencyContainerTest
    {
        [Test]
        public void SingletonInjectionTest()
        {
            var config = new ContainerConfiguration();
            config.Register<IRepository, Repository>();
            config.Register<IService, Service>();

            IDependencyContainer container = new ConfigurableDependencyContainer(config);
            var service = container.Resolve<IService>();

            Assert.IsNotNull(service);
        }

        [Test]
        public void PrototypeResolutionTest()
        {
            var config = new ContainerConfiguration();
            config.Register<IRepository, Repository>(DependencyScope.Prototype);
            IDependencyContainer container = new ConfigurableDependencyContainer(config);
            var repository = (IRepository) container.Resolve(typeof(IRepository));
            var repository2 = (IRepository) container.Resolve(typeof(IRepository));

            Assert.IsFalse(repository == repository2);
        }
    }
}