using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult List(int? categoryId, string? keyword)
        {
            return View();
        }
    }
}
