using ContactFormAPI.Domain;
using ContactFormAPI.DTOS;

namespace ContactFormAPI.Services
{
    public interface IMessageCreatorService
    {
        Message Save(Message msg);
    }
}
