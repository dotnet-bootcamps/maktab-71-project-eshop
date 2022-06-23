using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagAppService _tagAppService;

        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }
        public async Task<IActionResult> Index()
        {
            var operatorId = 5;
            var tags = await _tagAppService.GetAll();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, int tagCategoryId, bool hasValue)
        {
            await _tagAppService.Create(name, tagCategoryId, hasValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var tag = await _tagAppService.Get(id);
            return View(tag);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted)
        {
            await _tagAppService.Update(id, name, tagCategoryId,hasValue,isDeleted);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
