
using App.EndPoints.Mvc.AdminUI.Models;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult Index()
        {
            var brands = _brandRepository.GetAll();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandSaveViewModel model)
        {
            _brandRepository.Create(model);
            return RedirectToAction("Index");
            }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _brandRepository.GetBy(id);
            return View(model);
        }

        [HttpPost]

        public IActionResult Update(BrandSaveViewModel model)
        {
            _brandRepository.Update(model);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _brandRepository.Remove(id);
            return RedirectToAction("Index");        
        }
    }
}
