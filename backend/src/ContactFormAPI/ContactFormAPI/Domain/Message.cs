using System;

namespace ContactFormAPI.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}
