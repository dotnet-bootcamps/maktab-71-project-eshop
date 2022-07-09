using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Operator.Contract.AppServices;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Product;
using App.EndPoints.Mvc.AdminUI.Services;
using Newtonsoft.Json;

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
        private readonly IFileTypeAppService _fileTypeAppService;
        private readonly UploadService _uploadService;
        private readonly IConfiguration _configuration;
        private readonly ICategoryTagAppService _categoryTagAppService;
        // TODO : Operator

        public ProductController(
            IProductAppService appService,
            IBrandAppService brandAppService,
            IColorAppService colorAppService,
            IModelAppService modelAppService,
            ICategoryAppService categoryAppService,
            IOperatorAppService operatorAppService,
            IFileTypeAppService fileTypeAppService,
            UploadService uploadService,
            IConfiguration configuration,
            ICategoryTagAppService categoryTagAppService)
        {
            _productAppService = appService;
            _brandAppService = brandAppService;
            _colorAppService = colorAppService;
            _modelAppService = modelAppService;
            _categoryAppService = categoryAppService;
            _operatorAppService = operatorAppService;
            _fileTypeAppService = fileTypeAppService;
            _uploadService = uploadService;
            _configuration = configuration;
            _categoryTagAppService = categoryTagAppService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _productAppService.GetAll();
            var recordsProduct = records.Select(p => new ProductOutputViewModel()
            {
                Id = p.Id,
                ImageName = p.Files[0].Name,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                CategoryName = _categoryAppService.Get(p.CategoryId).Result.Name,
                Weight = p.Weight,
                Colors = p.Colors.Select(x => x.Code).ToList(),
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelName = _modelAppService.Get(p.ModelId).Result.Name,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorName = _operatorAppService.Get(p.OperatorId).Result.Name,
                BrandName = _brandAppService.Get(p.BrandId).Name,
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

        public async Task<IActionResult> GetTag(int id)
        {
            var tagDtos = await _categoryTagAppService.getTags(id);
            if (tagDtos == null)
            {
                return View();
            }
            var tagCategory = tagDtos.GroupBy(x => x.TagCategoryId)
                .Select(y => y.Select(x => new TagDto { Id = x.Id, HasValue = x.HasValue, Name = x.Name, TagCategoryName = x.TagCategoryName, IsMult = x.IsMult }).ToList())
                .ToList();

            ViewBag.selectListTags = tagCategory
                .Where(s => s.First().HasValue == false).ToList();

            ViewBag.inputTags = tagCategory.Where(s => s.First().HasValue == true)
                .SelectMany(s => s).ToList();
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel product, ICollection<IFormFile> files, CancellationToken cancellationToken, List<int> tags, Dictionary<int, string> input)
        {

            if (ModelState.IsValid)
            {
                #region SelectTag
                var tagList = await _categoryTagAppService.getTags(product.CategoryId);
                var selectTag = tagList.Where(t => tags.Contains(t.Id)).Select(x => new ProductTagDto()
                {
                    Name = tagList.FirstOrDefault(t => t.Id == x.Id).TagCategoryName,
                    Value = x.Name,
                    TagId = x.Id,
                }).ToList();
                foreach (var key in input.Keys)
                {
                    selectTag.Add(new ProductTagDto()
                    {
                        TagId = key,
                        Name = tagList.FirstOrDefault(x => x.Id == key).Name,
                        Value = input[key],
                    });
                }

                #endregion

                #region Upload&RecordFile

                var fileName = await _uploadService.AddFile(files);
                foreach (var file in fileName)
                {
                    product.FileIds.Add(_fileTypeAppService.Get(file).Id);
                }
                var listFile = await _fileTypeAppService.GetAll();
                var selectedFiles = listFile.Where(x => product.FileIds.Contains(x.Id)).ToList();

                #endregion

                #region SelectColor

                var colors = await _colorAppService.GetAll();

                var selectedColors = colors.Where(x => product.ColorIds.Contains(x.Id)).ToList();

                #endregion


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
                    Files = selectedFiles,
                    Tags = selectTag
                };
                //await _productAppService.Set(dto);
                //return RedirectToAction(nameof(Index));

                using var client = new HttpClient();
                var jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
                var httpResponse = await client.PostAsync("https://localhost:7146/api/Product/SetProduct", httpContent,
                    cancellationToken);
                var res = httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("خطایی در دریاغت اطلاعات رخ داد");
                }

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
