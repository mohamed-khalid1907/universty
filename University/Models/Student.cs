using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set;}
        public string LastTName { get; set;}
        [EmailAddress]
        public string Email { get; set;}
        public string Major { get; set;}
        public virtual ICollection<Course> Courses { set;  get; }
    }
}
