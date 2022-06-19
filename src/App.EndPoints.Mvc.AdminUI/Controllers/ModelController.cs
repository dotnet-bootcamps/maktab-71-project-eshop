
using App.Domain.Core.BaseData.Entities;

using Microsoft.AspNetCore.Mvc;


namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ModelController : Controller
    {

        public IActionResult Index()
        {
            //var models = _modelRepostitory.GetAll();
            //return View(models);
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Model model)
        {
            //_modelRepostitory.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            //var model = _modelRepostitory.GetById(Id);
            //return View(model);
            return View();
        }

        [HttpPost]
        public IActionResult Update(Model model)
        {
            //_modelRepostitory.Update(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //_modelRepostitory.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
