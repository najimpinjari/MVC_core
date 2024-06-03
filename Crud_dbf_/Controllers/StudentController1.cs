using Crud_dbf_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_dbf_.Controllers
{
    public class StudentController1 : Controller
    {
        StudentDBFContext _db;
        public StudentController1(StudentDBFContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
           // StudentDBFContext dB = new StudentDBFContext();
            var students = _db.CSstudents.ToList();
            return View(students);
        }
    }
}
