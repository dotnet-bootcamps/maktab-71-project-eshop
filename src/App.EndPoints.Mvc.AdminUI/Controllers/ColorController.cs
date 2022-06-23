using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorAppService _colorAppService;

        public ColorController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }


        public async Task<IActionResult> Index()
        {
            var operatorId = 10;
            var colors = await _colorAppService.GetAll();
            var colorModel = colors.Select(c => new ColorOutputViewModel()
            {
                Code = c.Code,
                Name = c.Name,
                Id = c.Id,
                CreationDate = c.CreationDate,
                IsDeleted = c.IsDeleted
            }).ToList();
            return View(colorModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorInputViewModel color)
        {
            await _colorAppService.Create(color.Name, color.Code);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var color = await _colorAppService.Get(id);
            var colorInput = new ColorOutputViewModel()
            {
                IsDeleted = color.IsDeleted,
                CreationDate = color.CreationDate,
                Code = color.Code,
                Id = id,
                Name = color.Name
            };
            return View(colorInput);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ColorOutputViewModel color)
        {
            await _colorAppService.Update(color.Id, color.Name, color.Code, color.IsDeleted);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorAppService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
