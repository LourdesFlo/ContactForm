﻿using System;

namespace ContactFormAPI.Services.Exceptions
{
    public class SendEmailException : Exception
    {
        public SendEmailException()
        {
        }

        public SendEmailException(string message)
            : base(message)
        {
        }

        public SendEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
