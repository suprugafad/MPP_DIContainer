#nullable enable
using System.Runtime.Serialization;

namespace DIContainer.Exception
{
    public class DependencyMissingException : System.Exception
    {
        public DependencyMissingException()
        {
        }

        protected DependencyMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DependencyMissingException(string? message) : base(message)
        {
        }

        public DependencyMissingException(string? message, System.Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}