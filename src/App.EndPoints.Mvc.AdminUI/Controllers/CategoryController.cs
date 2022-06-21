using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Mvc.AdminUI.Models;
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
            var categories = await _categoryAppService.GetAll();
            var categoriesModel = categories.Select(p => new CategoryOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                IsActive = p.IsActive,
                ParentCategoryId = p.ParentCagetoryId
            }).ToList();
            return View(categoriesModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputViewModel category)
        {
            var dto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                ParentCagetoryId = category.ParentCategoryId,
                CreationDate = DateTime.Now,
                DisplayOrder = category.DisplayOrder
            };
            await _categoryAppService.Set(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _categoryAppService.Get(id);
            var viewModel = new CategoryInputViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsActive=dto.IsActive,
                IsDeleted=dto.IsDeleted,
                ParentCategoryId= dto.ParentCagetoryId,
                DisplayOrder = dto.DisplayOrder,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryInputViewModel model)
        {
            var dto = new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                ParentCagetoryId = model.ParentCategoryId,
                CreationDate = DateTime.Now,
                DisplayOrder = model.DisplayOrder
            };
            await _categoryAppService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
