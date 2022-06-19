using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;



namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandAppService.GetBrands();
            var brandsModel= brands.Select(p=> new BrandOutputViewModel()
            {
                Id = p.Id,
                Name= p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted= p.IsDeleted,
            }).ToList();
            return View(brandsModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandInputViewModel brand)
        {
            await _brandAppService.SetBrand(brand.Name,brand.DisplayOrder);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var brand= _brandAppService.GetBrand(id);
            BrandOutputViewModel brandInput = new BrandOutputViewModel()
            {
               Id=id,
               Name = brand.Name,
               DisplayOrder=brand.DisplayOrder,
            };
            return View(brandInput);
        }

        [HttpPost]
        public IActionResult Update(BrandOutputViewModel brand)
        {
            _brandAppService.UpdateBrand(brand.Id,brand.Name,brand.DisplayOrder);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var brand = _brandAppService.GetBrand(id);
            return View(brand);

        }

        [HttpPost]
        public IActionResult DeleteBrand(int id)
        {
            _brandAppService.DeleteBrand(id);
            return RedirectToAction("");
        
        }

    }
}
