using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Ripository;
using App.Infrastructures.Database.SqlServer.Repositories;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        ProductEfRepository _productRepository;
        BrandRepository _brandRepository;
        ColorEfRepository _colorRepository;
        public ProductController(
            ProductEfRepository productRepository,
            BrandRepository brandRepository,
            ColorEfRepository colorRepository
            )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = _brandRepository.GetAll();
            ViewBag.color = _colorRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
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
