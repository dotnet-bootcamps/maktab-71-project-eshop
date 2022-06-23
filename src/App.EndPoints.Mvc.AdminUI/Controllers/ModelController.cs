using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelAppService _modelAppService;

        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }

        public async Task<IActionResult> Index()
        {
            var operatorId = 10;
            var models = await _modelAppService.GetAll();
            var modelView = models.Select(x => new ModelOutputViewModel()
            {
                Id = x.Id,
                BrandId = x.BrandId,
                CreationDate = x.CreationDate,
                IsDeleted = x.IsDeleted,
                Name = x.Name,
                ParentModelId = x.ParentModelId
            }).ToList();
            return View(modelView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelInputViewModel model)
        {
            await _modelAppService.Create(model.Name, model.ParentModelId, model.BrandId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _modelAppService.Get(id);
            var modelView = new ModelOutputViewModel()
            {
                Id = id,
                Name = model.Name,
                CreationDate = model.CreationDate,
                IsDeleted = model.IsDeleted,
                BrandId = model.BrandId,
                ParentModelId = model.ParentModelId
            };
            return View(modelView);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ModelOutputViewModel model)
        {
            await _modelAppService.Update(model.Id, model.Name, model.ParentModelId,model.BrandId, model.IsDeleted);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _modelAppService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
