using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {            
            _productAppService = productAppService;
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

        [HttpPost]
        public IActionResult Create(Product model)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Product model)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
