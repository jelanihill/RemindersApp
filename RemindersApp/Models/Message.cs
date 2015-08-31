using System;

namespace RemindersApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
