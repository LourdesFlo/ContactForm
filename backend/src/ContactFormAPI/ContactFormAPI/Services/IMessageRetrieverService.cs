using ContactFormAPI.Domain;
using System.Collections.Generic;

namespace ContactFormAPI.Services
{
    public interface IMessageRetrieverService
    {
        IEnumerable<Message> Get();
    }
}
