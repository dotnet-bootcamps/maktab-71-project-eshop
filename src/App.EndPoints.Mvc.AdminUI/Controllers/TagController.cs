using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Entities;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
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
            var tagModels=tags.Select(x => new TagOutputViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                HasValue = x.HasValue,
                IsDeleted = x.IsDeleted,
                TagCategoryId = x.TagCategoryId
            }).ToList();
            return View(tagModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagInputViewModel tag)
        {
            await _tagAppService.Create(tag.Name, tag.TagCategoryId, tag.HasValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var tag = await _tagAppService.Get(id);
            var tagInput = new TagOutputViewModel()
            {
                CreationDate = tag.CreationDate,
                HasValue = tag.HasValue,
                Id = id,
                IsDeleted = tag.IsDeleted,
                Name = tag.Name,
                TagCategoryId = tag.TagCategoryId
            };
            return View(tagInput);
        }

        [HttpPost]

        public async Task<IActionResult> Update(TagOutputViewModel tag)
        {
            await _tagAppService.Update(tag.Id, tag.Name, tag.TagCategoryId, tag.HasValue, tag.IsDeleted);
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
