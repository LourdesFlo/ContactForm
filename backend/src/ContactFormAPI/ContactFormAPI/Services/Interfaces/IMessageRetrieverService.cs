using ContactFormAPI.Domain;
using System;
using System.Collections.Generic;

namespace ContactFormAPI.Services
{
    public interface IMessageRetrieverService
    {
        IEnumerable<Message> Get();

        Message Get(Guid messageId);
    }
}
