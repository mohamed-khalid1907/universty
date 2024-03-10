using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public int ProfId { get; set; }
        [ForeignKey("ProfessorID")]
        public virtual Professor? Professor { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        
    }
}
