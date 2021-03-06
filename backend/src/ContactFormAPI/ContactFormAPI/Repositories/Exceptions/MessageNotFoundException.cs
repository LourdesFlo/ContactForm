﻿using System;

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
