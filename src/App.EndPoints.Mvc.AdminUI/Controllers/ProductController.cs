using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {            
            _productAppService = productAppService;
        }
        public IActionResult Index()
        {
            var operatorId = 10;
            var products = _productAppService.GetAllProducts(operatorId);
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var operatorId = 10;
            ViewBag.Brands = _productAppService.GetAllBrands(operatorId)
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Colors = _productAppService.GetAllColors(operatorId)
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = _productAppService.GetAllCategories(operatorId)
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Models = _productAppService.GetAllModels(operatorId)
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            _productAppService.CreateProduct(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            var record = _productAppService.GetProductById(Id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Product model)
        {
            _productAppService.UpdateProduct(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productAppService.RemoveProduct(id);
            return RedirectToAction("Index");
        }

    }
}
