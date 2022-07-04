using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
            var request = new HttpRequestMessage(HttpMethod.Get, @"https://localhost:7137/api/Brand");
            var response = await client.SendAsync(request, new CancellationToken());
            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<BrandOutputViewModel>());
            }
            var brands = JsonConvert.DeserializeObject<List<BrandDto>>(responseBody);

            // var brands = await _brandAppService.GetAll();
            var brandsModel = brands.Select(p => new BrandOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(brandsModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandAddViewModel brand, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }


            var client = new HttpClient();
            var jsonContent = JsonConvert.SerializeObject(new BrandDto
            {
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
            });
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
            var response = await client.PostAsync(@"https://localhost:7137/api/Brand", httpContent, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            return RedirectToAction(nameof(Index));
            // await _brandAppService.Set(brand.Name, brand.DisplayOrder);
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
