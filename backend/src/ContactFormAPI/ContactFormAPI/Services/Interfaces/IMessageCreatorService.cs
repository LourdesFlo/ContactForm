using ContactFormAPI.Domain;

namespace ContactFormAPI.Services
{
    public interface IMessageCreatorService
    {
        Message Save(Message msg);
    }
}
