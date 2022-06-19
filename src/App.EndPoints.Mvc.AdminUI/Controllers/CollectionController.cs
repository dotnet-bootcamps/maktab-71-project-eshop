using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository _repository;
        public CollectionController(ICollectionRepository repository)
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
        public IActionResult Create(Collection model)
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

        public IActionResult Update(Collection model)
        {
            _repository.Update(model);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Index");

        }
    }
}
