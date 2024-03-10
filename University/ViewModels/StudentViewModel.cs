using University.Models;

namespace University.ViewModels
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
