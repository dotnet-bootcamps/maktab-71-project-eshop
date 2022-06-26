using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult List(int? categoryId, string? keyword)
        {
            var model = new List<SearchItemViewModel>
            {
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
                new SearchItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                    ProductPrice = "15000"
                },
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = new SearchItemViewModel
            {
                ProductId = 1,
                ImageName = "productImage.jpg",
                ProductName = "ZBook HP ",
                ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
                ProductPrice = "15000"
            };
            return View(model);
        }
    }
}