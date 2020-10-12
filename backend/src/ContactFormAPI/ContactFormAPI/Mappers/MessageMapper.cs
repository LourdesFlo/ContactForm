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
            return new Message(dto.To, dto.From, dto.Subject, dto.Body);
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
