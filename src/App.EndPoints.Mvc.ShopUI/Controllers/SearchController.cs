using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IConfiguration _configuration;

        public SearchController(IProductAppService productAppService , IConfiguration configuration)
        {
            _productAppService = productAppService;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> List(int? categoryId, string? keyword,CancellationToken cancellationToken)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://localhost:7137/api/Product/GetProducts" + $"/?categoryId={categoryId}&keyword={keyword}");
                request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);

                var response = await client.SendAsync(request, cancellationToken);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyModel = JsonConvert.DeserializeObject<List<ProductBriefDto>>(responseBody);

                if (response.IsSuccessStatusCode == false)
                    throw new Exception("خطا در دریافت اطلاعات");
                if (responseBodyModel == null)
                {

                }
                else
                {
                    var viewmodel = responseBodyModel.Select(p => new SearchItemViewModel()
                    {
                        ProductId = p.Id,
                        BrandName = p.BrandName,
                        CategoryName = p.CategoryName,
                        Colors = p.Colors?.Select(c => c.Name).ToList(),
                        Price = p.Price is null ? null : p.Price.ToString(),
                        Count = p.Count,
                        Name = p.Name,
                        IsOrginal = p.IsOrginal,
                        ImageUrls =p.Files is null ? null : p.Files.Where(p => p.FileTypeId == 2).Select(p => "/upload/" + p.Name).ToList(),
                        VideoUrls = p.Files is null ? null : p.Files.Where(p => p.FileTypeId == 1).Select(p => "/upload/" + p.Name).ToList(),

                    }).ToList();
                    return View(viewmodel);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on GetCompanyIntegrationInfo endpoint of AtsIntegration , Error Message : {ex.Message}", ex);
            }
            //var model = await _productAppService.GetProducts(categoryId, keyword,null,null,null, cancellationToken);
            

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