using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.EndPoints.Mvc.AdminUI.ViewModels;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
    
        private readonly IColorRepository _colorRepository;


        public ColorsController(IColorRepository colorRepository)
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
        
        public IActionResult SubmitCreatedColor(ColorVM model)
        {
            _colorRepository.Create(new Infrastructures.Database.SqlServer.Entities.Color
            {
                Code = model.Code,
                Name = model.Name
            });

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
        
        public IActionResult SubmitUpdatedColor()
        {
            return View();
        }
    }
}
