using System.ComponentModel.DataAnnotations;

namespace RemindersApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Title has to be between 3 and 40 characters")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
