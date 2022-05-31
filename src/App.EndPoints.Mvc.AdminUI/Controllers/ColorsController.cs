using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorsController : Controller
    {
        public ColorsController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult SubmitCreatedColor()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }
        
        public IActionResult SubmitUpdatedColor()
        {
            return View();
        }
    }
}
