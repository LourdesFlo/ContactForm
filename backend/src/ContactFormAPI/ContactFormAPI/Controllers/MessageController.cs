﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<MessageDto> Send(MessageDto message)
        {
            Message savedMessage = _messageCreatorService.Save(mapper.FromDtoToDomain(message));

            if (savedMessage == null)
            {
                return NotFound();
            }

            try
            {
                _messageSender.Send(savedMessage);
            } 
            catch(Exception ex)
            {
                var exception = new SendEmailException("Error sending email", ex);
                exception.Data["MessageId"] = savedMessage.Id;

                _logger.LogError(exception, "Error sending email");
                throw exception;
            }

            return Ok(mapper.FromDomainToDto(savedMessage));
        }
    }
}
