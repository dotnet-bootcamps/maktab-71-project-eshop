using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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

        public async Task<IActionResult> Index(string? name,int? id)
        {
            using var client = new HttpClient();
            var query = new Dictionary<string, string?>()
{
                ["name"] = name,
                ["id"] = id.ToString()
            };
            var uri = QueryHelpers.AddQueryString("https://localhost:7137/api/Brand/GetBrands", query);
            client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
            var httpResponse = await client.GetAsync(uri);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("خطایی در دریافت اطلاعات رخ داد.");
            }
            var brandsModel = await httpResponse.Content.ReadFromJsonAsync<List<BrandOutputViewModel>>();
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
            //if (ModelState.IsValid && brand.Name.ToLower() == "hp" && brand.DisplayOrder > 2)
            //    ModelState.AddModelError("", "برند اچ پی باید در ابتدای لیست قرار بگیرد");
            if (ModelState.IsValid)
            {
                using var client = new HttpClient();
                var query = new Dictionary<string, string?>()
                {
                    ["name"] = brand.Name,
                    ["id"] = brand.Id.ToString()
                };
                var uri = QueryHelpers.AddQueryString("https://localhost:7137/api/Brand/SetBrand", query);
                client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
                var httpResponse = await client.PostAsync(uri, null, cancellationToken);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("خطایی در دریافت اطلاعات رخ داد.");
                }
                return RedirectToAction(nameof(Index));
                
            }
            return View(brand);
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
