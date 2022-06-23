using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.BaseData.Contracts.AppServices;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorAppService _colorAppService;

        public ColorController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }


        public async Task<IActionResult> Index()
        {
            var operatorId = 10;
            var colors = await _colorAppService.GetAll();
            return View(colors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string code)
        {
            await _colorAppService.Create(name, code);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var color = await _colorAppService.Get(id);
            return View(color);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, string code, bool isDeleted)
        {
            await _colorAppService.Update(id, name, code, isDeleted);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorAppService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
