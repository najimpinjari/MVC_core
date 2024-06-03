using Crud_dbfa_1.Models;
using Crud_dbfa_1.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingEFDBFirstApproach.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDBContext _db;
        public CategoryController(CategoryController db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category dbCategory = _db.Categories.Find(category.Id);

            if (ModelState.IsValid)
            {
                dbCategory.Name = category.Name;
                dbCategory.SellerName = category.SellerName;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            Category category = _db.Categories.Find(Id);

            _db.Categories.Remove(category);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
