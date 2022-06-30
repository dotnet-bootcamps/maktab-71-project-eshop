using Microsoft.AspNetCore.Mvc;
using App.Infrastructures.Database.SqlServer.Data;



using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Operator.Entities;
using App.Domain.Core.Operator.Contract.AppServices;
using Microsoft.AspNetCore.Mvc.Filters;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Product;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IBrandAppService _brandAppService;
        private readonly IColorAppService _colorAppService;
        private readonly IModelAppService _modelAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IOperatorAppService _operatorAppService;
        private readonly IPFileAppService _fileAppService;
        private readonly IWebHostEnvironment _environment;

        public ProductController(
            IProductAppService appService,
            IBrandAppService brandAppService,
            IColorAppService colorAppService,
            IModelAppService modelAppService,
            ICategoryAppService categoryAppService,
            IOperatorAppService operatorAppService,
            IPFileAppService fileAppService,
            IWebHostEnvironment environment
            )
        {
            _productAppService = appService;
            _brandAppService = brandAppService;
            _colorAppService = colorAppService;
            _modelAppService = modelAppService;
            _categoryAppService = categoryAppService;
            _operatorAppService = operatorAppService;
            _fileAppService = fileAppService;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _productAppService.GetAll();
            var recordsProduct = records.Select(p => new ProductOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                CategoryId = p.CategoryId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                BrandId = p.BrandId,
            }).ToList();
            return View(recordsProduct);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select
            (s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            var colors = await _colorAppService.GetAll();
            ViewBag.Colors = colors
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var categories = await _categoryAppService.GetAll();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var operators = await _operatorAppService.GetAll();
            ViewBag.Operators = operators
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel product)
        {

            if (ModelState.IsValid)
            {

                var formFile = product.Photo;
                if (formFile == null || formFile.Length == 0)
                {
                    ModelState.AddModelError("", "Uploaded file is empty or null.");
                    return View();
                }

                // Don't know where to put these!
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "Upload");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                var filePath = Path.Combine(uploadsRootFolder, formFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }




                var colors = await _colorAppService.GetAll();
                // select the selected colors
                var selectedColors = colors.Where(x => product.ColorIds.Contains(x.Id)).ToList();

                var dto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    CreationDate = DateTime.Now,
                    CategoryId = product.CategoryId,
                    Weight = product.Weight,
                    IsOrginal = product.IsOrginal,
                    Description = product.Description,
                    Count = product.Count,
                    ModelId = product.ModelId,
                    Price = product.Price,
                    IsShowPrice = product.IsShowPrice,
                    IsActive = product.IsActive,
                    OperatorId = product.OperatorId,
                    BrandId = product.BrandId,
                    Colors = selectedColors,
                };
                int productId = await _productAppService.Set(dto);

                await _fileAppService.Set(new PFileDto { FileName = formFile.FileName, Size = formFile.Length, ProductId = productId });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select
            (s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            var colors = await _colorAppService.GetAll();
            ViewBag.Colors = colors
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var categories = await _categoryAppService.GetAll();
            ViewBag.Categories = categories
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            var operators = await _operatorAppService.GetAll();
            ViewBag.Operators = operators
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

            var dto = await _productAppService.Get(id);
            var viewProduct = new ProductUpdateViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsDeleted = dto.IsDeleted,
                CategoryId = dto.CategoryId,
                Weight = dto.Weight,
                IsOrginal = dto.IsOrginal,
                Description = dto.Description,
                Count = dto.Count,
                ModelId = dto.ModelId,
                Price = dto.Price,
                IsShowPrice = dto.IsShowPrice,
                IsActive = dto.IsActive,
                OperatorId = dto.OperatorId,
                BrandId = dto.BrandId,
            };

            return View(viewProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var colors = await _colorAppService.GetAll();
            // select the selected colors
            var selectedColors = colors.Where(x => product.ColorIds.Contains(x.Id)).ToList();

            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
                CategoryId = product.CategoryId,
                Weight = product.Weight,
                IsOrginal = product.IsOrginal,
                Description = product.Description,
                Count = product.Count,
                ModelId = product.ModelId,
                Price = product.Price,
                IsShowPrice = product.IsShowPrice,
                IsActive = product.IsActive,
                OperatorId = product.OperatorId,
                BrandId = product.BrandId,
                Colors = selectedColors,
            };
            await _productAppService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<bool> CheckName(string name)
        {
            try
            {
                await _productAppService.Get(name);
                return false;
            }
            catch (Exception)
            {
                return true;
            }

        }
    }
}
