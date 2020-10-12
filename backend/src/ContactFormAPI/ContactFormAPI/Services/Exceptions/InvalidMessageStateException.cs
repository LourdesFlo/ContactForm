using System;

namespace ContactFormAPI.Services.Exceptions
{
    public class InvalidMessageStateException : Exception
    {
        public InvalidMessageStateException()
        {
        }

        public InvalidMessageStateException(string message)
            : base(message)
        {
        }

        public InvalidMessageStateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
