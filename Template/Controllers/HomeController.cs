using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template.Models;

namespace Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Repository.GetStudents());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View("RegisterForm");
        }

        [HttpPost]
        public IActionResult RegisterForm(StudentDetail student)
        {
            if (ModelState.IsValid)
            {
                Repository.AddStudent(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult StudentList()
        {
            return View("StudentList", Repository.GetStudents());
        }

        public IActionResult Edit(int id)
        {
            var student = Repository.GetStudentById(id);
            if (student != null)
            {
                return View("RegisterForm", student);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Repository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        [HttpPost]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
