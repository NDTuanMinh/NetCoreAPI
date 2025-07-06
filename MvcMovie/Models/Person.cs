using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Person
    {
        [Key]
        public string PersonId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
