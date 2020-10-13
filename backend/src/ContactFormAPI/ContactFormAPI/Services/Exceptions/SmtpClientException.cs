using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAPI.Services.Exceptions
{
    public class SmtpClientException : Exception
    {
        public SmtpClientException()
        {
        }

        public SmtpClientException(string message)
            : base(message)
        {
        }

        public SmtpClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
