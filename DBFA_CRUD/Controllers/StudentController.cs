using DBFA_CRUD.Models;
using DBFA_CRUD.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBFA_CRUD.Controllers
{
    public class StudentController : Controller
    {
        CSstudentDBFContext _db;
        public  StudentController(CSstudentDBFContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _db.CSstudents.ToList();
            return View(students);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create( CSstudent csstudent )
        {
            if (ModelState.IsValid) // use for property validation 
            {
                _db.CSstudents.Add(csstudent);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            var student = _db.CSstudents.Find(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _db.CSstudents.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(CSstudent csstudent)
        {
            if (ModelState.IsValid)
            {
                _db.CSstudents.Update(csstudent);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(csstudent);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _db.CSstudents.Find(id);
            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            CSstudent sstudent = _db.CSstudents.Find(Id);

            _db.CSstudents.Remove(sstudent);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddImage(int id)
        {
            var student = _db.CSstudents.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult AddImage(int id, IFormFile image)
        {
            var student = _db.CSstudents.Find(id);

            if (ModelState.IsValid && image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    student.StudImage = memoryStream.ToArray();
                }

                _db.CSstudents.Update(student);
                _db.SaveChanges();

                return RedirectToAction("Details", new { id });
            }

            return View(student);
        }

    }
}
