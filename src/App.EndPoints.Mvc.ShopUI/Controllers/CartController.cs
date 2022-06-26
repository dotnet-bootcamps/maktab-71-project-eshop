using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? categoryId, string? keyword)
        {
            var model = new List<CartItemViewModel>
            {
                new CartItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductPrice = "15000",
                    Count = 2,
                },
                new CartItemViewModel
                {
                    ProductId =1,
                    ImageName = "productImage.jpg",
                    ProductName = "ZBook HP ",
                    ProductPrice = "15000",
                    Count = 3,
                },
            };
            return View(model);
        }

     

    }
}