using ContactFormAPI.Domain;
using ContactFormAPI.Repositories;
using ContactFormAPI.Services.Exceptions;
using FluentEmail.Core;

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

        public async void Send(Message messageToSend)
        {
            if(!messageToSend.CanBeSend())
            {
                var exception = new InvalidMessageStateException("Cannot send email with current state");
                exception.Data["MessageId"] = messageToSend.Id;
                exception.Data["MessageState"] = messageToSend.State;
                throw exception;
            }

            _messageRepository.SetState(messageToSend.Id, MessageState.Sending);

            await _fluentEmail
                .SetFrom(messageToSend.From)
                .To(messageToSend.To)
                .Subject(messageToSend.Subject)
                .Body(messageToSend.Body)
            .SendAsync();
        }
    }
}
