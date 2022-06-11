using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.Infrastructures.Database.SqlServer.ViewModels.Model;

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
        public IActionResult Create(ModelSaveViewModel model)
        {
            _modelRepostitory.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var model = _modelRepostitory.GetById(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ModelSaveViewModel model)
        {
            _modelRepostitory.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _modelRepostitory.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
