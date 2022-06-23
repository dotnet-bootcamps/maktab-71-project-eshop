using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
        private readonly IColorAppService _colorAppService;

        public ColorsController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }
        public async Task<IActionResult> Index()
        {
            var result =await _colorAppService.GetAll();
            var colorsModel=result.Select(a => new ColorOutputViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Code = a.Code,
                CreationDate = a.CreationDate,
                IsDeleted = a.IsDeleted
            }).ToList() ;

            return View(colorsModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorInputViewModel colorModel)
        {
            //_colorRepository.Create(model);
            await _colorAppService.SetColor(colorModel.Code, colorModel.Name);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var c = await _colorAppService.Get(id);
            ColorOutputViewModel colorModel = new ColorOutputViewModel()
            {
                Id=id,
                Code=c.Code,
                Name=c.Name,
                CreationDate=c.CreationDate,
                IsDeleted=c.IsDeleted
            };
            return View(colorModel);
        }

        

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var c =await _colorAppService.Get(id);
            ColorOutputViewModel colorModel = new ColorOutputViewModel()
            {
                Id=id,
                Code=c.Code,
                Name=c.Name
            };
            return View(colorModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ColorOutputViewModel colorModel)
        {
            //_colorRepository.Edit(model);
            await _colorAppService.UpdateColor(colorModel.Id,colorModel.Code,colorModel.Name);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //_colorRepository.Delete(id);
            var color =await _colorAppService.Get(id);
            return View(color);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteColor(int id)
        {
            //_colorRepository.Delete(id);
            await _colorAppService.DeleteColor(id);
            return RedirectToAction("Index");
        }
    }
}
