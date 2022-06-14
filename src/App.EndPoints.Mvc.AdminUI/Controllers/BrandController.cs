
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _repository;
        public BrandController(IBrandRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var record = _repository.GetAll();
            return View(record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand model)
        {
            _repository.Create(model);
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
