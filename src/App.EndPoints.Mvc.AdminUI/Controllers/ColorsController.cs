using Microsoft.AspNetCore.Mvc;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;

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
        
        public IActionResult SubmitCreatedColor(ColorViewModel model)
        {
            _colorRepository.Create(new Color
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
        public IActionResult Create(Color model)
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
        public IActionResult Update(Color model)
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
