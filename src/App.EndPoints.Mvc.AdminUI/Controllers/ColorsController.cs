using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Ripository;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ColorRepository _colorRepository;
        public IActionResult Index()
        {
            var result = _colorRepository.GetAll();
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(App.Infrastructures.Database.SqlServer.Entities.Color model)
        {
            _colorRepository.Create(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(App.Infrastructures.Database.SqlServer.Entities.Color model)
        {
            _colorRepository.Edit(model);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            _colorRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
