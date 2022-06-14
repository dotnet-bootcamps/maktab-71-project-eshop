using App.Domain.Core.BaseData_Aggregate.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {
        private IModelRepository _modelRepostitory;

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepostitory = modelRepository;
        }

        public IActionResult Index()
        {
            var models = _modelRepostitory.GetAll();
            return View(models);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Model model)
        {
            _modelRepostitory.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var model = _modelRepostitory.GetById(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Model model)
        {
            _modelRepostitory.Update(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _modelRepostitory.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
