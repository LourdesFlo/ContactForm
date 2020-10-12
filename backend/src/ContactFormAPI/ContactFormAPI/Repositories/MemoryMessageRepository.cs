using ContactFormAPI.Domain;
using ContactFormAPI.Repositories.Exceptions;
using System;
using System.Collections.Generic;

namespace ContactFormAPI.Repositories
{
    public class MemoryMessageRepository : IMessageRepository
    {
        private static List<Message> messages = new List<Message>() {
            new Message("skaufman@example.com", "mpiotr@example.com", "Example", "Lorem Ipsum is simply dummy text of the printing and typesetting industry."), 
            new Message("sabren@example.com", "erynf@example.com", "Example 2", "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.")
        };

        public IEnumerable<Message> Get()
        {
            return messages;
        }

        public Message Save(Message msg)
        {
            messages.Add(msg);
            return msg;
        }

        public Message SetState(Guid id, MessageState newState)
        {
            Message message = GetMessageById(id);

            message.SetState(newState);

            return message;              
        }

        private Message GetMessageById(Guid id)
        {
            var message = messages.Find(m => m.Id.Equals(id));
            if (message == null)
            {
                MessageNotFoundException exception = new MessageNotFoundException("Message not found");
                exception.Data["MessageId"] = id;
                throw exception;
            }

            return message;
        }
    }
}
