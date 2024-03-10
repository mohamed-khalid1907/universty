using University.Models;

namespace University.ViewModels
{
    public class CourseViewModel
    {
        public  Course course { get; set; }
        public ICollection<Professor> Professors  { get; set; }
        public ICollection<Student> students  { get; set; }
    }
}
