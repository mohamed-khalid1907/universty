using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModels;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _db;
        public CourseController(AppDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            CourseViewModel model = new CourseViewModel();
            model.Professors=_db.Professors.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel model)
        {
            if (!ModelState.IsValid) {
            return View(model);
            }
            foreach (var item in _db.Professors.ToList())
            {
                if (item.ProfessorId == model.course.ProfId)
                {
                    model.course.Professor = item;
                }
            }
            _db.Courses.Add(model.course);
            _db.SaveChanges();
            return View("Index");
        }
        public IActionResult Update(int id)
        {
            Course course = _db.Courses.ToList().FirstOrDefault(e => e.CourseId == id);
            CourseViewModel model = new CourseViewModel();
            model.course = course;
            model.Professors = _db.Professors.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            foreach (var item in _db.Professors.ToList())
            {
                if (item.ProfessorId == model.course.ProfId)
                {
                    model.course.Professor = item;
                }
            }
            _db.Courses.Update(model.course);
            _db.SaveChanges();
            return View("Index");
        }
        public IActionResult Delete(int id)
        {
            Course course = _db.Courses.ToList().FirstOrDefault(e=> e.CourseId == id); 
            CourseViewModel model = new CourseViewModel();
            model.course = course;
            model.Professors = _db.Professors.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CourseViewModel model)
        {
            _db.Courses.Remove(model.course);
            _db.SaveChanges();
            return View();
        }
        public IActionResult Show()
        {
            List<Course> courses = _db.Courses.ToList();
            return View(courses);
        }
    }
}
