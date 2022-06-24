using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorAppService _colorService;

        public ColorsController(IColorAppService colorService)
        {
            _colorService = colorService;
        }
        
        public async Task<IActionResult> Index()
        {
            var Colors = await _colorService.GetColors();
            var ColorsModel = Colors.Select(p => new ColorOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                ColorCode = p.ColorCode,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(ColorsModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitCreatedColor(ColorInputViewModel color)
        {
            await _colorService.SetColor(color.Name, color.ColorCode);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            var color = _colorService.GetColor(id);
            ColorOutputViewModel colorOutput = new()
            {
                Id = color.Id,
                ColorCode = color.ColorCode,
                Name = color.Name,
                CreationDate = color.CreationDate
            };
            _colorService.DeleteColor(id);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Details(int id)
        {
            var color = _colorService.GetColor(id);
            var colorOutput = new ColorOutputViewModel()
            {
                Id = color.Id,
                ColorCode = color.ColorCode,
                CreationDate = color.CreationDate,
                Name = color.Name
            };

            return View(colorOutput);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var getColor=_colorService.GetColor(id);
            ColorOutputViewModel color = new ColorOutputViewModel()
            {
                Id = getColor.Id,
                Name = getColor.Name,
                ColorCode = getColor.ColorCode
            };
            return View(color);
        }
        [HttpPost]
        public IActionResult Update(ColorOutputViewModel color)
        {
            _colorService.UpdateColor(color.Id,color.Name,color.ColorCode);
            return RedirectToAction("Index");
        }



        //[HttpPost]
        //public IActionResult Delete(ColorOutputViewModel color)
        //{
        //    _colorService.DeleteColor(color.Id);
        //    return RedirectToAction("Index");
        //}
        
        public IActionResult SubmitUpdatedColor(ColorOutputViewModel color)
        {
            _colorService.UpdateColor(color.Id,color.Name,color.ColorCode);
            return RedirectToAction(nameof(Index));
        }
    }
}
