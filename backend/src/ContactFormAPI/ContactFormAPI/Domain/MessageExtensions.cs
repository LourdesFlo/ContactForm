using System;
namespace ContactFormAPI.Domain
{
    public static class MessageExtensions
    {
        public static bool CanBeSend(this Message messageToSend) {

            if (messageToSend.State == MessageState.Pending
                || messageToSend.State == MessageState.Failed)
            {
                return true;
            }

            return false;
        }
    }
}
