#nullable enable
using System.Runtime.Serialization;

namespace DIContainer.Exception
{
    public class DependencyInstantiationException : System.Exception
    {
        public DependencyInstantiationException()
        {
        }

        protected DependencyInstantiationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public DependencyInstantiationException(string? message) : base(message)
        {
        }

        public DependencyInstantiationException(string? message, System.Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}