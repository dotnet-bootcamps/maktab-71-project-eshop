using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ModelController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var operatorId = 10;
            var models = _productAppService.GetAllModels(operatorId);
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Model model)
        {
            _productAppService.CreateModel(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = _productAppService.GetModelById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Model model)
        {
            _productAppService.UpdateModel(model);
            return RedirectToAction("Update");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productAppService.RemoveModel(id);
            return RedirectToAction("Index");

        }
    }
}
