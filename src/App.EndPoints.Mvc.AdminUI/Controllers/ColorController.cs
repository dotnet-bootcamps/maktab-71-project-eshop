using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var colors = await _colorService.GetColors();
            var colorsModel = colors.Select(p => new ColorOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Code =p.Code,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(colorsModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorInputViewModel color)
        {
            await _colorService.SetColor(color.Name,color.Code);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var color = _colorService.GetColor(id);
            ColorOutputViewModel colorInput = new ColorOutputViewModel()
            {
                Id = id,
                Name = color.Name,
                Code=color.Code
            };
            return View(colorInput);
        }

        [HttpPost]
        public IActionResult Update(ColorOutputViewModel color)
        {
            _colorService.UpdateColor(color.Id, color.Name,color.Code);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var color = _colorService.GetColor(id);
            return View(color);

        }

        [HttpPost]
        public IActionResult DeleteColor(int id)
        {
            _colorService.DeleteColor(id);
            return RedirectToAction("");

        }
    }
}
