using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IProductAppService _productAppService;
        public ColorController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }


        public IActionResult Index()
        {
            var operatorId = 10;
            var record = _productAppService.GetAllColors(operatorId);
            return View(record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Color model)
        {
            _productAppService.CreateColor(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = _productAppService.GetColorById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Color model)
        {
            _productAppService.UpdateColor(model);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productAppService.RemoveColor(id);
            return RedirectToAction("Index");

        }
    }
}
