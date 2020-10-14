using ContactFormAPI.Domain;
using ContactFormAPI.Repositories;
using ContactFormAPI.Services.Exceptions;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using System;

namespace ContactFormAPI.Services
{
    public class FluentEmailMessageSender : IMessageSender
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IFluentEmail _fluentEmail;

        public FluentEmailMessageSender(IMessageRepository messageRepository, IFluentEmail fluentEmail)
        {
            _messageRepository = messageRepository;
            _fluentEmail = fluentEmail;
        }

        public void Send(Message messageToSend)
        {
            if(!messageToSend.CanBeSend())
            {
                var exception = new InvalidMessageStateException("Cannot send email with current state");
                exception.Data["MessageId"] = messageToSend.Id;
                exception.Data["MessageState"] = messageToSend.State;
                throw exception;
            }

            _messageRepository.SetState(messageToSend.Id, MessageState.Sending);

            try
            {
                SendResponse response = _fluentEmail
                    .SetFrom(messageToSend.From)
                    .To(messageToSend.To)
                    .Subject(messageToSend.Subject)
                    .Body(messageToSend.Body)
                    .SendAsync().Result;

                UpdateMessageResult(response, messageToSend);
            } 
            catch(Exception ex)
            {
                _messageRepository.SetState(messageToSend.Id, MessageState.Failed);
                var exception = new SmtpClientException("Error in SMTP client", ex);
                exception.Data["MessageId"] = messageToSend.Id;
                exception.Data["MessageState"] = messageToSend.State;
                throw exception;
            }
        }

        private void UpdateMessageResult(SendResponse response, Message message)
        {
            if (response.Successful)
            {
                _messageRepository.SetState(message.Id, MessageState.Send);
            }
            else
            {
                _messageRepository.SetState(message.Id, MessageState.Failed);
            }
        }
    }
}
