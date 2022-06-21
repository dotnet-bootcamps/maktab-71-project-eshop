using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contacts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Product.Dtos;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;

        public ProductController(
            IProductAppService productAppService,
            IBrandAppService brandAppService)
        {
            _productAppService = productAppService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            int operatorId = 1;
            var products = await _productAppService.GetAll(operatorId);
            var productsModel = products.Select(p => new ProductOutputViewModel()
            {
                Id = p.Id,
                Category = p.Category,
                Brand = p.Brand,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                Model = p.Model,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                Operator = p.Operator,
                OperatorId = operatorId,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(productsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var Brands = await _brandAppService.GetAll();
            ViewBag.Brands = Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
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
        public async Task<IActionResult> Create(ProductInputViewModel model)
        {
            int operatorId = 1;
            await _productAppService.Add(new ProductInputDto()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                ModelId = model.ModelId,
                Weight = model.Weight,
                IsOrginal = model.IsOrginal,
                Count = model.Count,
                IsActive = model.IsActive,
                IsShowPrice = model.IsShowPrice,
                OperatorId = operatorId,
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            int operatorId = 1;
            var Brands = await _brandAppService.GetAll();
            ViewBag.Brands = Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            });
            var product = await _productAppService.Get(operatorId, Id);
            var productModel = new ProductInputViewModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Weight = product.Weight,
                IsOrginal = product.IsOrginal,
                Description = product.Description,
                Count = product.Count,
                ModelId = product.ModelId,
                Price = product.Price,
                IsShowPrice = product.IsShowPrice,
                IsActive = product.IsActive,
                OperatorId = product.OperatorId,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
            };
            return View(productModel);
        }
        /// <summary>
        /// Update Product by recived properties form model and operator property will be changed to editor operator.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInputViewModel model)
        {
            int operatorId = 1;
            await _productAppService.Update(model.Id, new ProductInputDto
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                ModelId = model.ModelId,
                Weight = model.Weight,
                IsOrginal = model.IsOrginal,
                Count = model.Count,
                IsActive = model.IsActive,
                IsShowPrice = model.IsShowPrice,
                OperatorId = operatorId,
            }, model.IsDeleted);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            int operatorId = 1;
            await _productAppService.Delete(operatorId, Id);
            return RedirectToAction("Index");
        }

    }
}
