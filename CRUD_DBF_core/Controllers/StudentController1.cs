using CRUD_DBF_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DBF_core.Controllers
{
    public class StudentController1 : Controller
    {
        DBFContext _db;
        public StudentController1(DBFContext db)
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
