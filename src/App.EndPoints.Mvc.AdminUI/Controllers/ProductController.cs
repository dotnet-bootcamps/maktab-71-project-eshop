using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IProductAppService _productAppService;

        public ProductController(IProductRepository repository,ICategoryRepository catRepo
            ,IBrandRepository brandRepo
            ,IColorRepository colorRepo
            ,IModelRepository modelRepo
            , IProductAppService productAppService)
        {
            _repository = repository;
            _categoryRepository = catRepo;
            _brandRepository = brandRepo;
            _colorRepository = colorRepo;
            _modelRepository = modelRepo;
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

            ViewBag.Colors = _colorRepository.GetAll()
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
            var record = _repository.GetById(Id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Product model)
        {
            _repository.Update(model);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
