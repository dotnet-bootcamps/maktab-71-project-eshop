using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData;
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
            var operatorId = 10;
            var brands= await _brandAppService.GetAll();
            var brandModel=brands.Select(p=>new BrandOutputViewModel()
            {
                CreationDate=p.CreationDate,
                DisplayOrder=p.DisplayOrder,
                IsDeleted=p.IsDeleted,
                Id=p.Id,
                Name=p.Name
            }).ToList();
            return View(brandModel.OrderBy(x=>x.DisplayOrder));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandInputVeiwModel brand)
        {
            await _brandAppService.Create(brand.Name,brand.DisplayOrder);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var brand = await _brandAppService.Get(id);
            BrandOutputViewModel brandInput = new BrandOutputViewModel()
            {
                Id = id,
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
                IsDeleted=brand.IsDeleted
            };
            return View(brandInput);
        }

        [HttpPost]

        public async Task<IActionResult> Update(BrandOutputViewModel brand)
        {
            await _brandAppService.Update(brand.Id,brand.Name,brand.DisplayOrder);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandAppService.Delete(id);
            return RedirectToAction("Index");

        }

    }
}
