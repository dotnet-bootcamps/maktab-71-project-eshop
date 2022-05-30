using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        BrandRepository _brandRepository;
        public BrandController()
        {
            _brandRepository = new BrandRepository();
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
        public IActionResult Create(Brand model)
        {
            _brandRepository.Create(model);
            return RedirectToAction("");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Brand brand=_brandRepository.GetById(id);
            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(Brand model)
        {
            _brandRepository.Edit(model);
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
            _brandRepository.Delete(id);
            return RedirectToAction("");
        }

    }
}
