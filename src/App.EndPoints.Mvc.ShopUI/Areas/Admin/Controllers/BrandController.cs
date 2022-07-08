using System.Text;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IConfiguration _configuration;

        public BrandController(IBrandAppService brandAppService, IConfiguration configuration)
        {
            _brandAppService = brandAppService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //var brands = await _brandAppService.GetAll();
            //var brandsModel = brands.Select(p => new BrandOutputViewModel()
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    DisplayOrder = p.DisplayOrder,
            //    CreationDate = p.CreationDate,
            //    IsDeleted = p.IsDeleted,
            //}).ToList();
            //return View(brandsModel);
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://localhost:7146/api/Brand/GetBrands");
                request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);

                var response = await client.SendAsync(request, cancellationToken);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyModel = JsonConvert.DeserializeObject<List<BrandBriefDto>>(responseBody);
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("خطا در دریافت اطلاعات");
                }
                if (responseBodyModel == null)
                { }
                else
                {
                    var viewModel = responseBodyModel.Select(b => new BrandOutputViewModel()
                    {
                        Id = b.Id,
                        Name = b.Name,
                        DisplayOrder = b.DisplayOrder,
                        CreationDate = b.CreatedDate
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandAddViewModel brand, CancellationToken cancellationToken)
        {
            //if (ModelState.IsValid && brand.Name.ToLower() == "hp" && brand.DisplayOrder > 2)
            //    ModelState.AddModelError("", "برند اچ پی باید در ابتدای لیست قرار بگیرد");
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            var dto = new BrandDto()
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
            };
            using var client = new HttpClient();
            var jsonContent = JsonConvert.SerializeObject(dto);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
            var httpResponse = await client.PostAsync("https://localhost:7146/api/Brand/SetBrand", httpContent,
                cancellationToken);
            var res = httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("خطایی در دریاغت اطلاعات رخ داد");
            }
            return RedirectToAction(nameof(Index));
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
    }
}
