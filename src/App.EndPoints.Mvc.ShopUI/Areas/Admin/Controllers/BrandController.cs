using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;



namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;
        private readonly IBrandService _brandService;

        public BrandController(IBrandAppService brandAppService, IBrandService brandService)
        {
            _brandAppService = brandAppService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandAppService.GetAll();
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
        public async Task<IActionResult> Create(BrandAddViewModel brand)
        {
            //if (ModelState.IsValid && brand.Name.ToLower() == "hp" && brand.DisplayOrder > 2)
            //    ModelState.AddModelError("", "برند اچ پی باید در ابتدای لیست قرار بگیرد");
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            await _brandAppService.Set(brand.Name, brand.DisplayOrder);
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
