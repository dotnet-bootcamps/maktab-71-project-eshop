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


        [HttpGet]
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

        [HttpPost]
        public IActionResult Create(string model)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Update()

        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(string model)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string model)
        {
            return View();
        }
        
        public IActionResult SubmitUpdatedColor()
        {
            return View();
        }
    }
}
