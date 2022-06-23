using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData;
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
            var operatorId = 10;
            var categories = await _categoryAppService.GetAll();
            var categoryModels = categories.Select(p => new CategoryOutPutViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                ParentCagetoryId = p.ParentCagetoryId,
                IsDeleted = p.IsDeleted,
                IsActive = p.IsActive
            }).ToList();
            return View(categoryModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputViewModel category)
        {
            await _categoryAppService.Create(category.Name, category.DisplayOrder, category.ParentCagetoryId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryAppService.Get(id);
            var categoryInput = new CategoryOutPutViewModel()
            {
                DisplayOrder = category.DisplayOrder,
                Name = category.Name,
                ParentCagetoryId = category.ParentCagetoryId
            };
            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryOutPutViewModel category)
        {
            await _categoryAppService.Update(category.Id, category.Name, category.DisplayOrder, category.ParentCagetoryId, category.IsActive, category.IsDeleted);    
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
