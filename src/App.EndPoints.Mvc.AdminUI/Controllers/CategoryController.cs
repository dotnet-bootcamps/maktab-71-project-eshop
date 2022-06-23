using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Product.Contacts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using App.EndPoints.Mvc.AdminUI.ViewModels;


using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAppService.GetCategories();
            var categoryModel = categories.Select(p => new CategoryOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                ParentCategoryId=p.ParentCategoryId,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(categoryModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryOutputViewModel brand)
        {
            await _categoryAppService.SetCategory(brand.Name, brand.DisplayOrder,brand.ParentCategoryId);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _categoryAppService.GetCategory(id);
            CategoryOutputViewModel categoryInput = new CategoryOutputViewModel()
            {
                Id = id,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                ParentCategoryId = category.ParentCategoryId
            };
            return View(categoryInput);
        }
        [HttpPost]
        public IActionResult Update(CategoryOutputViewModel category)
        {
            _categoryAppService.UpdateCategory(category.Id, category.Name, category.DisplayOrder, category.ParentCategoryId);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryAppService.GetCategory(id);
            return View(category);

        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            _categoryAppService.DeleteCategory(id);
            return RedirectToAction("");

        }

    }
}
