using App.Domain.AppServices.Product;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Entities;
using App.EndPoints.Mvc.AdminUI.ViewModels;


using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryAppService _categoryAppService;

        public async Task<IActionResult> Index()
        {
            var categorys = await _categoryAppService.GetCategorys();

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            category.AddCategory(model);
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var cat = category.Details(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {
                category.Edit(model);
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(category.Details(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfrim(int id)
        {
            category.Delete(id);
            return View();
        }
    }
}
