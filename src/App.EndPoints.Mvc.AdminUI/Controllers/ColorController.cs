using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Contacts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {

        private readonly IColorAppService _appService;

        public ColorController(IColorAppService appService)
        {
            _appService = appService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _appService.GetAll();
            var categoriesModel = categories.Select(p => new ColorOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                IsActive = p.IsActive,
                ParentColorId = p.ParentCagetoryId
            }).ToList();
            return View(categoriesModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorInputViewModel color)
        {
            var dto = new ColorDto
            {
                Id = color.Id,
                Name = color.Name,
                IsActive = color.IsActive,
                IsDeleted = color.IsDeleted,
                ParentCagetoryId = color.ParentColorId,
                CreationDate = DateTime.Now,
                DisplayOrder = color.DisplayOrder
            };
            await _appService.Set(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _appService.Get(id);
            var viewModel = new ColorInputViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsActive = dto.IsActive,
                IsDeleted = dto.IsDeleted,
                ParentColorId = dto.ParentCagetoryId,
                DisplayOrder = dto.DisplayOrder,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ColorInputViewModel model)
        {
            var dto = new ColorDto
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                ParentCagetoryId = model.ParentColorId,
                CreationDate = DateTime.Now,
                DisplayOrder = model.DisplayOrder
            };
            await _appService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _appService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
