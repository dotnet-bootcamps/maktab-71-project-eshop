
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductAppService _productAppService;
        public BrandController(IBrandRepository brandRepository
            ,IProductAppService productAppService)

        {
            _productAppService = productAppService;
            _brandRepository = brandRepository;
        }

        public IActionResult Index()
        {
            var brands = _productAppService.GetAllBrands();
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
            _brandRepository.Create(model);
            return RedirectToAction("");
            }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Brand brand=_brandRepository.GetBy(id);
            return View(brand);
        }

        [HttpPost]

        public IActionResult Update(Brand model)
        {
            _brandRepository.Update(model);
            return RedirectToAction("");
        }

        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    return View();
        //}        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _brandRepository.Remove(id);
            return RedirectToAction("");
        
        }

    }
}
