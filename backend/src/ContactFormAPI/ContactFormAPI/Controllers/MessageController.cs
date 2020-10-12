using System;
using System.Collections.Generic;
using System.Linq;
using ContactFormAPI.Domain;
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

        public MessageController(ILogger<MessageController> logger, IMessageRetrieverService messageRetrieverService)
        {
            _logger = logger;
            _messageRetrieverService = messageRetrieverService;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _messageRetrieverService.Get().ToList();
        }
    }
}
