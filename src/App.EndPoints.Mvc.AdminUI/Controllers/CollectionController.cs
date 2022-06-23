using App.Domain.Core.Product.Contracts.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionAppService _collectionAppService;

        public CollectionController(ICollectionAppService collectionAppService)
        {
            _collectionAppService = collectionAppService;
        }
        public async  Task<IActionResult> Index()
        {
            var collections =await _collectionAppService.GetAll();
            var collectionModels=collections.Select(x=>new CollectionOutputViewModel()
            {
                CreationDate=x.CreationDate,
                Id=x.Id,
                Name=x.Name,
                IsDeleted=x.IsDeleted
            }).ToList();
            return View(collections);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CollectionInputViewModel collection)
        {
            await _collectionAppService.Create(collection.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var collection = await _collectionAppService.Get(id);
            var collectionInput = new CollectionOutputViewModel()
            {
                Id = id,
                IsDeleted = collection.IsDeleted,
                Name = collection.Name,
                CreationDate = collection.CreationDate,
            };
            return View(collectionInput);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CollectionOutputViewModel collection)
        {
            await _collectionAppService.Update(collection.Id, collection.Name, collection.IsDeleted);
            return RedirectToAction("Update");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _collectionAppService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
