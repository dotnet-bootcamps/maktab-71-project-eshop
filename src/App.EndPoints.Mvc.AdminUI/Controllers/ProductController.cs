using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;

        public ProductController(IProductAppService productAppService, IBrandAppService brandAppService)
        {
            _productAppService = productAppService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productAppService.GetProducts();
            var outViewProducts = products.Select(x => new ProductOutputViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                IsOrginal = x.IsOrginal,
                Weight = x.Weight,
                Count = x.Count,
                IsShowPrice = x.IsShowPrice,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Description = x.Description,
                IsActive = x.IsActive,
                ModelId = x.ModelId,
                Price = x.Price
            }).ToList();
            return View(outViewProducts);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
             var brands =await _brandAppService.GetBrands();
             ViewBag.Brands=brands.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            //ViewBag.Colors = _colorRepository.GetAll()
            //    .Select(s => new SelectListItem
            //    {
            //        Text = s.Name,
            //        Value = s.Id.ToString()
            //    });

            //ViewBag.Categories = _categoryRepository.GetAll()
            //    .Select(s => new SelectListItem
            //    {
            //        Text = s.Name,
            //        Value = s.Id.ToString()
            //    });

            //ViewBag.Models = _modelRepository.GetAll()
            //    .Select(s => new SelectListItem
            //    {
            //        Text = s.Name,
            //        Value = s.Id.ToString()
            //    });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductOutputViewModel model)
        {
            await _productAppService.SetProduct(model.CategoryId, model.BrandId, model.Weight, model.IsOrginal,
                model.Description, model.Count, model.ModelId, model.Price, model.operatorId, model.IsShowPrice,
                model.Name);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            //var product = _productRepository.GetById(Id);
            //return View(product);
            return View();
        }

        [HttpPost]
        public IActionResult Update(Product model1)
        {
            //_productRepository.Edit(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //_productRepository.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}