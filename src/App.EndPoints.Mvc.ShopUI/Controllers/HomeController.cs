using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Domain.Core.Product.Contacts.AppServices;
using App.EndPoints.Mvc.ShopUI.ViewModels;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;

        public HomeController(ILogger<HomeController> logger, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            var model = _categoryAppService.GetAll().Result.Select(x => new CategoryVM()
            {
                id = x.Id,
                name = x.Name,
                image = x.Image
            }).ToList();
            ViewBag.Categorys = model;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}