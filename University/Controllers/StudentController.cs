using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModels;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            StudentViewModel model = new StudentViewModel();
            model.Courses=_db.Courses.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            _db.students.Add(model.student);
            _db.SaveChanges();
            return View("Index");
        }
        public IActionResult Update(int id)
        {
            StudentViewModel model = new StudentViewModel();
            Student student = _db.students.ToList().FirstOrDefault(e=>e.StudentId == id);
            model.student = student;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _db.students.Update(model.student);
            _db.SaveChanges();
            return View("Index");
        }
        public IActionResult Delete(int id)
        {
            StudentViewModel model = new StudentViewModel();
            Student student = _db.students.ToList().FirstOrDefault(e => e.StudentId == id);
            model.student = student;
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(StudentViewModel model)
        {
            _db.students.Remove(model.student);
            _db.SaveChanges();
            return View("Index");
        }

        public IActionResult ViewStudents()
        {
            ICollection<Student>students=_db.students.ToList();
            return View(students);
        }public IActionResult AssignCourse(int id)
        {
            Student student = _db.students.ToList().FirstOrDefault(e=>e.StudentId == id);
            AssignViewModel model = new AssignViewModel();
            model.student = student;
            model.Courses=_db.Courses.Include(e=>e.CourseName).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AssignCourse(AssignViewModel model)
        {
            model.student.Courses.Add(model.course);
            Course course =  _db.Courses.ToList().FirstOrDefault(e=>e.CourseId==model.course.CourseId);
            course.Students.Add(model.student);
            _db.Courses.Update(course);
            _db.students.Update(model.student);
            _db.SaveChanges();
            return View("index");
        }
    }
}
