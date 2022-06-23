using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using App.Domain.Core.Product.Dtos;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task<IActionResult> Index()
        {
            var productDto = await _productAppService.GetAll();
            var products = productDto.Select(x => new ProductOutputViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                BrandId = x.BrandId,
                ModelId = x.ModelId,
                OperatorId = x.OperatorId,
                Count = x.Count,
                CreationDate = x.CreationDate,
                Description = x.Description,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                IsOrginal = x.IsOrginal,
                IsShowPrice = x.IsShowPrice,
                Price = x.Price,
                Weight = x.Weight
            }).ToList();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInputViewModel model)
        {
            var operatorId = 10;
            var product = new ProductInputDto()
            {
                BrandId = model.BrandId,
                Name = model.Name,
                CategoryId = model.CategoryId,
                Count = model.Count,
                Description = model.Description,
                IsOrginal = model.IsOrginal,
                ModelId = model.ModelId,
                Price = model.Price,
                Weight = model.Weight
            };
            await _productAppService.Create(product, operatorId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var productDto = await _productAppService.Get(id);
            var product = new ProductOutputViewModel()
            {
                Description = productDto.Description,
                CreationDate = productDto.CreationDate,
                IsDeleted = productDto.IsDeleted,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                Count = productDto.Count,
                Id = id,
                IsActive = productDto.IsActive,
                IsOrginal = productDto.IsOrginal,
                IsShowPrice = productDto.IsShowPrice,
                ModelId = productDto.ModelId,
                Name = productDto.Name,
                OperatorId = productDto.OperatorId,
                Price = productDto.Price,
                Weight = productDto.Weight
            };
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductOutputViewModel model)
        {
            var product = new ProductUpdateDto()
            {
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Count = model.Count,
                Id = model.Id,
                IsActive = model.IsActive,
                IsOrginal = model.IsOrginal,
                IsShowPrice = model.IsShowPrice,
                ModelId = model.ModelId,
                Name = model.Name,
                Price = model.Price,
                Weight = model.Weight
            };
            await _productAppService.Update(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
