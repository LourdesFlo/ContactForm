using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAPI.Services.Exceptions
{
    public class SmptClientException : Exception
    {
        public SmptClientException()
        {
        }

        public SmptClientException(string message)
            : base(message)
        {
        }

        public SmptClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
