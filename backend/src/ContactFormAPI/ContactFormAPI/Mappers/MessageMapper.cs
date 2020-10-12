using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactFormAPI.Mappers
{
    public class MessageMapper
    {
        public Message FromDtoToDomain(MessageDto dto)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                To = dto.To,
                From = dto.From,
                Subject = dto.Subject,
                Body = dto.Body,
                Date = DateTime.Now
            };
        }

        public MessageDto FromDomainToDto(Message message)
        {
            return new MessageDto
            {
                To = message.To,
                From = message.From,
                Subject = message.Subject,
                Body = message.Body,
                Date = message.Date
            };
        }
    }
}
