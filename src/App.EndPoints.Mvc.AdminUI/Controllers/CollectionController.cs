using App.Domain.Core.Product.Contracts.AppServices;
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
            return View(collections);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            await _collectionAppService.Create(name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var collection = await _collectionAppService.Get(id);
            return View(collection);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, string name, bool isDeleted)
        {
            await _collectionAppService.Update(id, name, isDeleted);
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
