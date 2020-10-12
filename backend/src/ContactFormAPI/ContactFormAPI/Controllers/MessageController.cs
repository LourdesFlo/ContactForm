using System;
using System.Collections.Generic;
using System.Linq;
using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;
using ContactFormAPI.Mappers;
using ContactFormAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactFormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRetrieverService _messageRetrieverService;
        private readonly IMessageCreatorService _messageCreatorService;
        private MessageMapper mapper;

        public MessageController(ILogger<MessageController> logger, IMessageRetrieverService messageRetrieverService, IMessageCreatorService messageCreatorService)
        {
            _logger = logger;
            _messageRetrieverService = messageRetrieverService;
            _messageCreatorService = messageCreatorService;
            mapper = new MessageMapper();
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _messageRetrieverService.Get().ToList();
        }

        [HttpPost]
        public MessageDto Save(MessageDto message)
        {
            Message savedMessage = _messageCreatorService.Save(mapper.FromDtoToDomain(message));
            return mapper.FromDomainToDto(savedMessage);
        }
    }
}
