
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _repository;
        private readonly IProductAppService _productAppService;

        public BrandController(IBrandRepository repository,IProductAppService productAppService)
        {
            _repository = repository;
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var operatorId = 10;
            var brands=_productAppService.GetAllBrands(operatorId);
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand model)
        {
            _productAppService.CreateBrand(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = _repository.GetById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Brand model)
        {
            _repository.Update(model);
            return RedirectToAction("Update");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Index");

        }

    }
}
