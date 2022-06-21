
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {

        private readonly IModelAppService _appService;

        public ModelController(IModelAppService appService)
        {
            _appService = appService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _appService.GetAll();
            var recordsModel = records.Select(p => new ModelOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                ParentModelId = p.ParentModelId,
                BrandId = p.BrandId,
            }).ToList();
            return View(recordsModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelInputViewModel model)
        {
            var dto = new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                IsDeleted = model.IsDeleted,
                CreationDate = DateTime.Now,
                ParentModelId = model.ParentModelId,
                BrandId = model.BrandId,
            };
            await _appService.Set(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _appService.Get(id);
            var viewModel = new ModelInputViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsDeleted = dto.IsDeleted,
                BrandId= dto.BrandId,
                ParentModelId = dto.ParentModelId
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ModelInputViewModel model)
        {
            var dto = new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                IsDeleted = model.IsDeleted,
                BrandId = model.BrandId,
                ParentModelId = model.ParentModelId
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
