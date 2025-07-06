using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Person")]
    public class Employee : Person
    {
        [Key]
        public int Age { get; set; }
    }
}
