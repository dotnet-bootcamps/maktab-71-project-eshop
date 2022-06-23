using App.Domain.Core.BaseData.Contracts.AppServices;
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
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, int displayOrder, int parentCategoryId)
        {
            await _categoryAppService.Create(name, displayOrder, parentCategoryId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryAppService.Get(id);
            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, int displayOrder, int parentCategoryId, bool isActive, bool isDeleted)
        {
            await _categoryAppService.Update(id, name, displayOrder, parentCategoryId, isActive, isDeleted);    
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
