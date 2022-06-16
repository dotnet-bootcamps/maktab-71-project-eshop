using App.Domain.Core.ProductAgg.Contracts.ApplicationServices;
using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Domain.Core.ProductAgg.DTOs;
using App.Domain.Core.ProductAgg.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandApplicationService _brandApplicationService;
        public BrandController(IBrandApplicationService brandApplicationService)
        {
            _brandApplicationService = brandApplicationService;
        }

        public IActionResult Index()
        {
            var brands = _brandApplicationService.GetBrands();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBrand model)
        {
            _brandApplicationService.Create(model);
            return RedirectToAction("");
            }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Brand brand = _brandApplicationService.GetBrandBy(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Update(Brand model)
        {
            _brandApplicationService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _brandApplicationService.Delete(id);
            return RedirectToAction("Index");
        
        }

    }
}
