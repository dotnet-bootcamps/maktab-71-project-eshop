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

        public SearchController(IProductAppService productAppService, IConfiguration configuration)
        {
            _productAppService = productAppService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> List(int? categoryId, string? keyword,CancellationToken cancellationToken)
        {
            //var model = _productAppService.GetAll().Result
            //    .Where(x=>(categoryId==null||x.CategoryId==categoryId))
            //    .Select(x => new SearchItemViewModel
            //{
            //    ProductName = x.Name,
            //    ProductId = x.Id,
            //    ColoList = x.Colors,
            //    ImageName = x.Files.Select(i=>i.Name).ToList(),
            //    ProductDescription = x.Description,
            //    ProductPrice = x.Price.ToString()
            //}).ToList();
            //return View(model);
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://localhost:7146/api/Product/GetProducts" + $"/?categoryId={categoryId}&keyword{keyword}");
                request.Headers.Add("ApiKey",_configuration.GetSection("ApiKey").Value);

                var response = await client.SendAsync(request, cancellationToken);
                var responseBody=await response.Content.ReadAsStringAsync();
                var responseBodyModel=JsonConvert.DeserializeObject<List<ProductBriefDto>>(responseBody);
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("خطا در دریافت اطلاعات");
                }

                if (responseBodyModel == null)
                {

                }
                else
                {
                    var viewModel = responseBodyModel.Select(p => new SearchItemViewModel()
                    {
                        ProductName = p.Name,
                        ColoList = p.Colors,
                        ProductPrice = p.Price.ToString(),
                        ImageName = p.Files.Select(x=>x.Name).ToList(),
                        ProductId = p.Id,
                        ProductDescription = p.Description
                    }).ToList();
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on GetCompanyIntegrationInfo endpoint of AtsIntegration , Error Message : {ex.Message}", ex);
            }
            return View();
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
                ColoList = product.Colors,
                ProductTags = product.Tags
            };
            return View(model);
        }
    }
}