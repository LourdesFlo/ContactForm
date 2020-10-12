using ContactFormAPI.Domain;
using ContactFormAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAPI.Services
{
    public class MessageRetrieverService : IMessageRetrieverService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageRetrieverService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> Get()
        {
            return _messageRepository.Get();
        }
    }
}
