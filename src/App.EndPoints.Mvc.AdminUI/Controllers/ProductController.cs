using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IModelRepository _modelRepository;
        public ProductController(IProductRepository repository,ICategoryRepository catRepo
            ,IBrandRepository brandRepo
            ,IColorRepository colorRepo
            ,IModelRepository modelRepo)
        {
            _repository = repository;
            _categoryRepository = catRepo;
            _brandRepository = brandRepo;
            _colorRepository = colorRepo;
            _modelRepository = modelRepo;
        }
        public IActionResult Index()
        {
            var record = _repository.GetAll();
            return View(record);
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
            _repository.Create(new Product
            {
                Name = model.Name,
                Description=model.Description,
                Price=model.Price,
                BrandId=model.BrandId,
                CategoryId=model.CategoryId,
                ModelId = model.ModelId
            });
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
