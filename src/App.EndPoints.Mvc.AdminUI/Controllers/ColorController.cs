using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.BaseData.Entities;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {

        private readonly IColorRepository _repository;
        public ColorController(IColorRepository repository)
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
        public IActionResult Create(Color model)
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

        public IActionResult Update(Color model)
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
