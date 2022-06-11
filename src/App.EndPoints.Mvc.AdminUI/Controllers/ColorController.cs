using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.EndPoints.Mvc.AdminUI.ViewModels;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {
    
        private readonly IColorRepository _colorRepository;


        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        
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
        
        public IActionResult Create(ColorSaveViewModel model)
        {
            _colorRepository.Create(model);

            return RedirectToAction(nameof(Index));
        }
       

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _colorRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ColorSaveViewModel model)
        {
            _colorRepository.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _colorRepository.Delete(id);
            return RedirectToAction("Index");
        }       
    }
}
