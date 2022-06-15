using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _repository;
        private readonly IProductAppService _productAppService;

        public TagController(ITagRepository repository, IProductAppService productAppService)
        {
            _repository = repository;
            _productAppService = productAppService;
        }
        public IActionResult Index()
        {
            var operatorId = 5;
            var tags=_productAppService.GetAllTags(operatorId);
            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag model)
        {
            _productAppService.CreateTag(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = _repository.GetById(id);
            return View(record);
        }

        [HttpPost]

        public IActionResult Update(Tag model)
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
