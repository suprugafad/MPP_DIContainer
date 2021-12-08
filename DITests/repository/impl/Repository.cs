namespace DITests.repository.impl
{
    public class Repository : IRepository
    {
        private static int i = 0;

        public Repository()
        {
            i++;
        }

        public object Find()
        {
            throw new System.NotImplementedException();
        }
    }
}