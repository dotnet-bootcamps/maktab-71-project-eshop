using App.EndPoints.Mvc.AdminUI.ViewModels;
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
        public async Task<IActionResult> Create(BrandInputViewModel brand)
        {
            await _brandAppService.Set(brand.Name, brand.DisplayOrder);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var brand = _brandAppService.Get(id);
            BrandOutputViewModel brandInput = new BrandOutputViewModel()
            {
                Id = id,
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
            };
            return View(brandInput);
        }

        [HttpPost]
        public IActionResult Update(BrandOutputViewModel brand)
        {
            _brandAppService.Update(brand.Id, brand.Name, brand.DisplayOrder, brand.IsDeleted);
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var brand = _brandAppService.Get(id);
            return View(brand);

        }

        [HttpPost]
        public IActionResult DeleteBrand(int id)
        {
            _brandAppService.Delete(id);
            return RedirectToAction("");

        }

    }
}
