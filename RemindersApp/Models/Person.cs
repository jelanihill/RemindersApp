using System.Collections.Generic;

namespace RemindersApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname{ get; set; }
        public string Lastname { get; set; }

        public IList<Message> Messages { get; set; }
    }
}
