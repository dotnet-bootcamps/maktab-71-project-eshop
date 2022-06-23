
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Entities;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {
        private readonly IProductModelAppService _productModelAppService;
        private readonly IBrandAppService _brandAppService;

        public ModelController(IProductModelAppService productModelAppService, IBrandAppService brandAppService)
        {
            _productModelAppService = productModelAppService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var productModels = await _productModelAppService.GetProductModels();
            var productModel = productModels.Select(p => new ProductModelOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                BrandName = p.Brand.Name,
                CreationDate = p.CreationDate,
                ParentModelId = p.ParentModelId,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(productModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = (await _brandAppService.GetBrands())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModelOutputViewModel ProductModel)
        {
            await _productModelAppService.SetProductModel(ProductModel.Name, ProductModel.ParentModelId, ProductModel.BrandId);
            return RedirectToAction("");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Brands = (await _brandAppService.GetBrands())
            .Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });

            var productModel = _productModelAppService.GetProductModel(id);
            ProductModelOutputViewModel productModelInput = new ProductModelOutputViewModel()
            {
                Id = id,
                Name = productModel.Name,
                BrandName = productModel.Brand.Name,
                CreationDate = productModel.CreationDate,
                ParentModelId = productModel.ParentModelId,
                IsDeleted = productModel.IsDeleted,
            };
            return View(productModelInput);
        }

        [HttpPost]
        public IActionResult Update(ProductModelOutputViewModel ProductModel)
        {
            _productModelAppService.UpdateProductModel(ProductModel.Id, ProductModel.Name,
                ProductModel.ParentModelId, ProductModel.BrandId);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productModel = _productModelAppService.GetProductModel(id);
            return View(productModel);
        }

        [HttpPost]
        public IActionResult DeleteProductModel(int id)
        {
            _productModelAppService.DeleteProductModel(id);
            return RedirectToAction("");
        }

    }
}
