using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class CategoryListVM : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
