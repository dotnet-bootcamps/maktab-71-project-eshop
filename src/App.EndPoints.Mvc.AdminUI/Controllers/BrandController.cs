using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;
namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IProductAppService _productAppService;

        public BrandController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var operatorId = 10;
            var brands=_productAppService.GetAllBrands(operatorId);
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand model)
        {
            _productAppService.CreateBrand(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record =_productAppService.GetBrandById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Brand model)
        {
            _productAppService.UpdateBrand(model);
            return RedirectToAction("Update");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productAppService.RemoveBrand(id);
            return RedirectToAction("Index");

        }

    }
}
