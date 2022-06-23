using App.Domain.Core.BaseData.Contracts.AppServices;
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
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name,int displayOrder)
        {
            await _brandAppService.Create(name,displayOrder);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var brand = await _brandAppService.Get(id);
            return View(brand);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, int displayOrder)
        {
            await _brandAppService.Update(id,name,displayOrder);
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
