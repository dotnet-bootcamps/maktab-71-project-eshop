using App.Domain.Core.Product.Contacts.AppServices;
using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductAppService _productAppService;

        public SearchController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult List(int? categoryId, string? keyword)
        {
            var model = _productAppService.GetAll().Result.Where(x=>x.CategoryId==categoryId).Select(x => new SearchItemViewModel
            {
                ProductName = x.Name,
                ProductId = x.Id,
                ColoList = x.Colors,
                ImageName = x.Files.Select(i=>i.Name).ToList(),
                ProductDescription = x.Description,
                ProductPrice = x.Price.ToString()
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productAppService.Get(id);
            var model = new SearchItemViewModel()
            {
                ProductId = id,
                ImageName = product.Files.Select(x => x.Name).ToList(),
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.Price.ToString(),
                ColoList = product.Colors
            };
            return View(model);
        }
    }
}