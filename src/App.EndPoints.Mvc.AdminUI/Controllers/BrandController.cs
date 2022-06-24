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
            var brands = await _brandAppService.GetAll();
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
            //if (ModelState.IsValid && brand.Name.ToLower() == "hp" && brand.DisplayOrder > 2)
            //    ModelState.AddModelError("", "برند اچ پی باید در ابتدای لیست قرار بگیرد");

            if (ModelState.IsValid)
            {
                await _brandAppService.Set(brand.Name, brand.DisplayOrder);
                return RedirectToAction("");
            }
            return View(brand);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var brand= _brandAppService.Get(id);
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
            _brandAppService.Update(brand.Id,brand.Name,brand.DisplayOrder, brand.IsDeleted);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _brandAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public bool CheckName(string Manefacture)
        {
            if (Manefacture.Contains("hp"))
                return true;
            return false;
        }
    }
}
