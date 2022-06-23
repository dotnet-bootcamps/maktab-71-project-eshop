using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.Product.Contarcts.Repositories;
using App.Domain.Core.Product.Dtos;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    public class ProductController2 : Controller
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly AppDbContext _dbContext;

        public ProductController2(IProductQueryRepository productQueryRepository,AppDbContext dbContext)
        {
            _productQueryRepository = productQueryRepository;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var products =await _productQueryRepository.GetAll();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brands = _dbContext.Brands.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
               });
            ViewBag.Colors = _dbContext.Colors.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = _dbContext.Categories.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Models = _dbContext.Models.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            List<SelectListItem> boolSelectListItem = new List<SelectListItem>();
            boolSelectListItem.Add(new SelectListItem()
            {
                Text="Yes",
                Value=true.ToString()
            });
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "No",
                Value = false.ToString()
            }); 
            ViewBag.IsOrginal = boolSelectListItem;
            ViewBag.IsShowPrice = boolSelectListItem;
            ViewBag.IsActive = boolSelectListItem;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDTO model)
        {
            model.IsDeleted = false;
            
            Product pr = new Product()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name=model.Name,
                IsShowPrice = model.IsShowPrice,
                Price=model.Price,
                

            };
            _dbContext.Products.Add(pr);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {

            var model = _dbContext.Products.SingleOrDefault(x => x.Id == id);
            ViewBag.Brands = _dbContext.Brands.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Colors = _dbContext.Colors.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            ViewBag.Categories = _dbContext.Categories.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            ViewBag.Models = _dbContext.Models.ToList()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            List<SelectListItem> boolSelectListItem = new List<SelectListItem>();
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "Yes",
                Value = true.ToString()
            });
            boolSelectListItem.Add(new SelectListItem()
            {
                Text = "No",
                Value = false.ToString()
            });
            ViewBag.IsOrginal = boolSelectListItem;
            ViewBag.IsShowPrice = boolSelectListItem;
            ViewBag.IsActive = boolSelectListItem;
            ProductDTO productDTO = new ProductDTO() {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,
            };


            return View(productDTO);
            
        }
        [HttpPost]
        public IActionResult Update(ProductDTO model)
        {
            Product pr = new Product()
            {
                Id=model.Id,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,


            };
            _dbContext.Products.Update(pr);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
   
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _productQueryRepository.Get(id);
            return View(model);

        }
        [HttpPost]
        public IActionResult DeletePost(ProductDTO model)
        {
            Product pr = new Product()
            {
                Id = model.Id
            };
            _dbContext.Products.Remove(pr);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
