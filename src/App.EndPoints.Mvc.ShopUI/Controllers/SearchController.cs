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
        public async Task<IActionResult> List(int? categoryId, string? keyword,CancellationToken cancellationToken)
        {

            var model = await _productAppService.GetProducts(categoryId, keyword,null,null,null, cancellationToken);
            if(model == null)
            {

            }
            else
            {
                var viewmodel = model.Select(p => new SearchItemViewModel()
                {
                    ProductId=p.Id,
                    BrandName=p.BrandName,
                    CategoryName=p.CategoryName,
                    Colors=p.Colors?.Select(c=>c.Name).ToList(),
                    Price=p.Price.ToString(),
                    Count=p.Count,
                    Name=p.Name,
                    IsOrginal=p.IsOrginal,
                    ImageUrls=p.Files.Where(p=>p.FileTypeId==2).Select(p=> "/upload/" + p.Name).ToList(),
                    VideoUrls=p.Files.Where(p=>p.FileTypeId==1).Select(p=> "/upload/" + p.Name).ToList(),
                    
                }).ToList();
                return View(viewmodel);
            }

            return View();

            
            
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //var model = new SearchItemViewModel
            //{
            //    ProductId = 1,
            //    ImageName = "productImage.jpg",
            //    ProductName = "ZBook HP ",
            //    ProductDescription = "لپ تاپ اچ پی زد بوک نسل 3 ",
            //    ProductPrice = "15000"
            //};
            return View();
        }
    }
}