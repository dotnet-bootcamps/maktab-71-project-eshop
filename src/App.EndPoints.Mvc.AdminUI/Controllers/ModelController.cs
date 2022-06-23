using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.AppServices;

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
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, int parentModelId, int brandId)
        {
            await _modelAppService.Create(name, parentModelId, brandId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _modelAppService.Get(id);
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, int parentModelId, int brandId, bool isDeleted)
        {
            await _modelAppService.Update(id, name, parentModelId,brandId, isDeleted);
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
