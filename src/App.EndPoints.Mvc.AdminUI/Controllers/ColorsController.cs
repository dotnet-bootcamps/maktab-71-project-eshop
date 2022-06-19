using Microsoft.AspNetCore.Mvc;

using App.EndPoints.Mvc.AdminUI.ViewModels;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
        
        public IActionResult Index()
        {
            //var result = _colorRepository.GetAll();
            //return View(result);
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult SubmitCreatedColor(ColorViewModel model)
        {
            //_colorRepository.Create(new Infrastructures.Database.SqlServer.Entities.Color
            //{
            //    Code = model.Code,
            //    Name = model.Name
            //});

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id)
        {
            //_colorRepository.Create(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update()

        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
            //_colorRepository.Edit(model);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            //_colorRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult SubmitUpdatedColor()
        {
            return View();
        }
    }
}
