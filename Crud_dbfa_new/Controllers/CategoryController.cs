using Crud_dbfa_new.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Crud_dbfa_new.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDBContext _db;

        public CategoryController(CategoryDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}
