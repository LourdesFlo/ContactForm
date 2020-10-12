using System;

namespace ContactFormAPI.Domain
{
    public enum MessageState
    {
        Failed = -1,
        Send = 1,
        Pending = 2,
    }

    public class Message
    {
        public Guid Id { get; private set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; private set; }
        public MessageState State { get; private set; }

        public Message(string to, string from, string subject, string body)
        {
            Id = Guid.NewGuid();
            To = to;
            From = from;
            Subject = subject;
            Body = body;
            Date = DateTime.Now;
            State = MessageState.Pending;
        }
    }
}
