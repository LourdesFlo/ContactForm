using ContactFormAPI.Domain;
using System.Collections.Generic;

namespace ContactFormAPI.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Get();

        Message Save(Message msg);
    }
}
