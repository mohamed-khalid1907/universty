using University.Models;

namespace University.ViewModels
{
    public class AssignViewModel
    {
        public Student student { get; set; }
        public Course course { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
