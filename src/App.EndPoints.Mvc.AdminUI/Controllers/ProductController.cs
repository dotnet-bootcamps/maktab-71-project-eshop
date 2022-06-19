using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
       


        public IActionResult Index()
        {
            //var products = _productRepository.GetAll();
            //return View(products);
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Brands = _brandRepository.GetAll()
            //    .Select(s => new SelectListItem
            //    {
            //        Text = s.Name,
            //        Value = s.Id.ToString()
            //    });

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
        public IActionResult Create(CreateProductViewModel model)
        {
            //_productRepository.Create(new Product
            //{
            //    Name = model.Name,
            //    Description=model.Description,
            //    Price=model.Price,
            //    BrandId=model.BrandId,
            //    CategoryId=model.CategoryId,
            //    ModelId = model.ModelId
            //});
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
