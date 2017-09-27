using System;
namespace TechAndWings.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
