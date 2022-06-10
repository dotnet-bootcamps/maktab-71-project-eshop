using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IModelRepository _modelRepository;

        public ProductController(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IColorRepository colorRepository,
            IModelRepository modelRepository
            )
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _modelRepository = modelRepository;
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = _brandRepository.GetAll()
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

            ViewBag.Categories = _categoryRepository.GetAll()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Models = _modelRepository.GetAll()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            _productRepository.Create(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            var product = _productRepository.GetById(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product model)
        {
            _productRepository.Edit(model);

            return RedirectToAction("Index");
        }
   


        //[HttpGet]
        //public IActionResult Delete()
        //{
         

        //    return View();
        //}
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _productRepository.Delete(Id);

            return RedirectToAction("Index");
        }

    }
}
