using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductAppService _productAppService;
        public CategoryController(ICategoryRepository repository,IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var operatorId = 10;
            var categories=_productAppService.GetAllCategories(operatorId);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            _productAppService.CreateCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = _productAppService.GetCategoryById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Category model)
        {
            _productAppService.UpdateCategory(model);
            return RedirectToAction("Update");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productAppService.RemoveCategory(id);
            return RedirectToAction("Index");
        }
    }
}
