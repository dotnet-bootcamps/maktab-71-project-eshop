using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.IRepository;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryRepo _db;
        public CategoryController(ICategoryRepo db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var allCategory = _db.GetCategories;
            return View(allCategory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            _db.Create(model);
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var cat=_db.Retrieve(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {
                _db.Update(model);
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_db.Retrieve(id));
        }
        [HttpPost ,ActionName("Delete")]
        public IActionResult DeleteConfrim(int id)
        {
            _db.Delete(id);
            return View();
        }
    }
}
