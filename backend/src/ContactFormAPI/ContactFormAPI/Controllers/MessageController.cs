using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;
using ContactFormAPI.Mappers;
using ContactFormAPI.Services;
using ContactFormAPI.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactFormAPI.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRetrieverService _messageRetrieverService;
        private readonly IMessageCreatorService _messageCreatorService;
        private readonly IMessageSender _messageSender;
        private MessageMapper mapper;

        public MessageController(ILogger<MessageController> logger, IMessageRetrieverService messageRetrieverService, IMessageCreatorService messageCreatorService, IMessageSender messageSender)
        {
            _logger = logger;
            _messageRetrieverService = messageRetrieverService;
            _messageCreatorService = messageCreatorService;
            _messageSender = messageSender;
            mapper = new MessageMapper();
        }

        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Message> Get()
        {
            return _messageRetrieverService.Get().ToList();
        }

        [HttpPost]
        [Route("[controller]")]
        public MessageDto Save(MessageDto message)
        {
            Message savedMessage = _messageCreatorService.Save(mapper.FromDtoToDomain(message));
            return mapper.FromDomainToDto(savedMessage);
        }

        [HttpPost]
        [Route("[controller]/{id}/send")]
        public IActionResult Send([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out Guid messageId))
            {
                return BadRequest();
            }

            var message = _messageRetrieverService.Get(messageId);
            if (message == null)
            {
                return NotFound();
            }

            try
            {
                _messageSender.Send(message);
            } 
            catch(Exception ex)
            {
                var exception = new SendEmailException("Error sending email", ex);
                exception.Data["MessageId"] = messageId;

                _logger.LogError(exception, "Error sending email");
                return StatusCode(500);   
            }

            return Ok();
        }
    }
}
