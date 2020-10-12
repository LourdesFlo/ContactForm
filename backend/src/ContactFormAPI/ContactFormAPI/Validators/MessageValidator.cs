using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;
using FluentValidation;

namespace ContactFormAPI.Validators
{
    public class MessageValidator : AbstractValidator<MessageDto>
    {
        private const int SubjectMaxLength = 78;
        private const int BodyMaxLength = 456;

        public MessageValidator()
        {
            RuleFor(to => to.To).NotNull().NotEmpty().EmailAddress();
            RuleFor(from => from.From).NotNull().NotEmpty().EmailAddress();
            RuleFor(subject => subject.Subject).MaximumLength(SubjectMaxLength);
            RuleFor(body => body.Body).MaximumLength(BodyMaxLength);
        }
    }
}
