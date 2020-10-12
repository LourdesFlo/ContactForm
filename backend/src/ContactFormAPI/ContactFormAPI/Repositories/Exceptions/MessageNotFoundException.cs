using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAPI.Repositories.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException()
        {
        }

        public MessageNotFoundException(string message)
            : base(message)
        {
        }

        public MessageNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
