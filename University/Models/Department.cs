using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Department
    {
        [Key]
        public int DepartmebtID { get; set; }
        public virtual ICollection<Professor> professors { get; set; }
    }
}
