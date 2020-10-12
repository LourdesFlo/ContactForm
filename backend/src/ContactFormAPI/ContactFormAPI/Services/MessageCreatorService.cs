using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;
using ContactFormAPI.Repositories;
using System;

namespace ContactFormAPI.Services
{
    public class MessageCreatorService : IMessageCreatorService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageCreatorService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Message Save(Message message)
        {
            return _messageRepository.Save(message);
        }
    }
}
