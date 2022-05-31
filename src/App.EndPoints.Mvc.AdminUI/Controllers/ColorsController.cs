using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Ripository;
using App.Infrastructures.Database.SqlServer.Entities;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
    
        private readonly ColorRepository _colorRepository;


        public ColorsController()
        {
            _colorRepository = new ColorRepository();
        }
        
        public IActionResult Index()
        {
            return View(_colorRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult SubmitCreatedColor(Color model)
        {
            model.CreationDate = DateTime.Now;
            model.IsDeleted = false;
            _colorRepository.Create(model);
            return View("Index", _colorRepository.GetAll());
        }

        public IActionResult Update(int id)
        {
            return View(_colorRepository.GetById(id));
        }

        public IActionResult SubmitUpdatedColor(Color model)
        {
            _colorRepository.Edit(model);
            return View("Index", _colorRepository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _colorRepository.Delete(id);
            return View("Index", _colorRepository.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            return View(_colorRepository.GetById(id));
        }

        public IActionResult Back()
        {
            return View("Index", _colorRepository.GetAll());
        }

    }
}
