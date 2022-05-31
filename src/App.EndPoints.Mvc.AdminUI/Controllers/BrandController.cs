using App.EndPoints.Mvc.AdminUI.Models;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandRepository _repo = new();
        public IActionResult Index()
        {
            var model=_repo.GetAll()
                .Where(x=>x.IsDeleted!)
                .Select(x=>new BrandDTO 
                {
                    Id=x.Id,
                    Name=x.Name,
                    CreationDate=x.CreationDate,
                    DisplayOrder=x.DisplayOrder
                })
                .ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new BrandDTO();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BrandDTO model)
        {
            var brand = new Brand()
			{
                Name = model.Name,
                CreationDate = DateTime.Now,
                DisplayOrder = model.DisplayOrder,
			};
            _repo.Create(brand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var brand = _repo.GetById(id);
            var model =new BrandDTO() { 
                Id=brand.Id,
                Name=brand.Name,
                CreationDate=brand.CreationDate,
                DisplayOrder=brand.DisplayOrder,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BrandDTO model)
        {
            _repo.Edit(new Brand()
            {
                Id = model.Id,
                Name = model.Name,
                CreationDate = model.CreationDate,
                DisplayOrder = model.DisplayOrder,
            });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
