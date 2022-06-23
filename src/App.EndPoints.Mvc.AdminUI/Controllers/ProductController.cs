using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using App.Domain.Core.Product.Dtos;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductModelAppService _productModelAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;

        public ProductController(IProductModelAppService productModelAppService,
            ICategoryAppService categoryAppService,
            IProductAppService productAppService,
            IBrandAppService brandAppService)
        {
            _productModelAppService = productModelAppService;
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _productAppService.GetProducts();
            var productModel = product.Select(p => new ProductOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ProductModelId = p.ProductModelId,
                ProductModelName = p.ProductModel.Name,
                Price = p.Price,
                CreationDate = p.CreationDate
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

            ViewBag.Categories = (await _categoryAppService.GetCategories())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Models = (await _productModelAppService.GetProductModels())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Brands = (await _brandAppService.GetBrands())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = (await _categoryAppService.GetCategories())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Models = (await _productModelAppService.GetProductModels())
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var product = _productAppService.GetProduct(id);
            ProductOutputViewModel productModelInput = new ProductOutputViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                BrandId = product.BrandId,
                BrandName = product.Brand.Name,
                Weight = product.Weight,
                IsOrginal = product.IsOrginal,
                Description = product.Description,
                Count = product.Count,
                ProductModelId = product.ProductModelId,
                ProductModelName = product.ProductModel.Name,
                Price = product.Price,
                CreationDate = product.CreationDate
            };
            return View(productModelInput);
        }
        [HttpPost]
        public IActionResult Update(ProductOutputViewModel Product)
        {
            UpdateProductDto updateProductDto = new UpdateProductDto
            {
                Id = Product.Id,
                IsOrginal = Product.IsOrginal,
                Price = Product.Price,
                BrandId = Product.BrandId,
                CategoryId = Product.CategoryId,
                Description = Product.Description,
                ModelId = Product.ProductModelId,
                Name = Product.Name,
                Weight = Product.Weight
            };
            _productAppService.UpdateProduct(updateProductDto);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productAppService.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult DeleteProductModel(int id)
        {
            _productAppService.DeleteProduct(id);
            return RedirectToAction("");
        }

    }
}
