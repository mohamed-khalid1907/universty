using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Professor
    {
        [Key]
       public int ProfessorId { get; set; }
        [Required]
        public  string ProfessorName { get; set;}
        public int DepID { get; set; }
        [ForeignKey("DepatrmentId")]
        public virtual Department department { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }

    }
}
