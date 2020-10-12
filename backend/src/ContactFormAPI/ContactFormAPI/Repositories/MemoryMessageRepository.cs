using ContactFormAPI.Domain;
using System;
using System.Collections.Generic;

namespace ContactFormAPI.Repositories
{
    public class MemoryMessageRepository : IMessageRepository
    {
        private static List<Message> messages = new List<Message>() {
            new Message()
            {
                Id = Guid.NewGuid(),
                To = "Prueba@gmail.com",
                From = "PruebaFrom@gmail.com",
                Subject = "Asunto Prueba",
                Body = "Mensaje Prueba",
                Date = DateTime.Now
            }, 
            new Message()
            {
                                Id = Guid.NewGuid(),
                To = "Prueba2@gmail.com",
                From = "PruebaFrom2@gmail.com",
                Subject = "Asunto Prueba 2",
                Body = "Mensaje Prueba 2",
                Date = DateTime.Now
            }
        };

        public IEnumerable<Message> Get()
        {
            return messages;
        }
    }
}
