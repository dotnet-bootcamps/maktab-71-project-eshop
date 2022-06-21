using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos.Color;

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
            var records = await _appService.GetAll();
            var recordsModel = records.Select(p => new ColorOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                Code = p.Code,
            }).ToList();
            return View(recordsModel);
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
                IsDeleted = color.IsDeleted,              
                CreationDate = DateTime.Now,
                Code = color.Code,
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
                IsDeleted = dto.IsDeleted,
                Code = dto.Code,
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
                IsDeleted = model.IsDeleted,
                Code = model.Code 
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
