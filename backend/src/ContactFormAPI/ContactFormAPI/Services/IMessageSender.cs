using ContactFormAPI.Domain;
namespace ContactFormAPI.Services
{
    public interface IMessageSender
    {
        public void Send(Message msg);
    }
}
