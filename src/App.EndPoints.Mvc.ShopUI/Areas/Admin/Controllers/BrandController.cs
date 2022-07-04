using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IBrandService _brandService;
        private readonly IConfiguration _configuration;

        public BrandController(IBrandAppService brandAppService, IBrandService brandService, IConfiguration configuration)
        {
            _brandAppService = brandAppService;
            _brandService = brandService;
            _configuration = configuration;
        }
        
        public async Task<IActionResult> Index()
        {
            /*var brands = await _brandAppService.GetAll();
            var brandsModel = brands.Select(p => new BrandOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();*/

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://localhost:7137/api/Brand/Index");
                //var headr = _configuration.GetSection("ApiKey").Value;
                request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyModel = JsonConvert.DeserializeObject<List<BrandDto>>(responseBody);
                if (response.IsSuccessStatusCode == false)
                    throw new Exception("خطا در دریافت اطلاعات");
                if (responseBodyModel == null)
                {

                }
                else
                {
                    var brandsViewModel = responseBodyModel.Select(p => new BrandOutputViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        DisplayOrder = p.DisplayOrder,
                        CreationDate = p.CreationDate,
                        IsDeleted = p.IsDeleted,
                    }).ToList();
                    return View(brandsViewModel);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandAddViewModel brand,CancellationToken cancellationToken)
        {
            /*if (!ModelState.IsValid)
            {
                return View(brand);
            }
            await _brandAppService.Set(brand.Name, brand.DisplayOrder);*/

            try
            {
                var dto = new BrandDto()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    DisplayOrder=brand.DisplayOrder,
                    
                };
                using var client = new HttpClient();
                var jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                /*client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);*/
                var httpResponse = await client.PostAsync("https://localhost:7137/api/Brand/SetBrand", httpContent, cancellationToken);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("خطایی در دریافت اطلاعات رخ داد.");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception accord", ex);
            }
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var brand = _brandAppService.Get(id);
            var brandInput = new BrandUpdateViewModel
            {
                Id = id,
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
                IsDeleted = brand.IsDeleted,
            };
            return View(brandInput);
        }

        [HttpPost]
        public IActionResult Update(BrandUpdateViewModel brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            _brandAppService.Update(brand.Id, brand.Name, brand.DisplayOrder, brand.IsDeleted);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _brandAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public bool CheckName(string name)
        {
            try
            {
                _brandService.EnsureDoesNotExist(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
