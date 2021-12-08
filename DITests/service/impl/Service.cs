using DITests.repository;

namespace DITests.service.impl
{
    public class Service : IService
    {
        private IRepository Repository;

        public Service(IRepository repository)
        {
            Repository = repository;
        }

        public void DoSomething()
        {
            throw new System.NotImplementedException();
        }
    }
}