
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Model;
using App.EndPoints.Mvc.AdminUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {

        private readonly IModelAppService _modelAppService;
        private readonly IBrandAppService _brandAppService;

        public ModelController(IModelAppService appService, IBrandAppService brandAppService)
        {
            _modelAppService = appService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {


            //var records = await _modelAppService.GetAll();
            var client=new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7137/api/Model/GetModels");
            var response = await client.SendAsync(request);
            var responsebody=await response.Content.ReadAsStringAsync();
            var records=JsonConvert.DeserializeObject<List<ModelDto>>(responsebody);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("خطا در دریافت اطلاعات");
            }
            else if (responsebody is null)
            {

            }
            else
            {
            var recordsModel = records.Select(p => new ModelOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
                ParentModelId = p.ParentModelId,
                BrandId = p.BrandId,
            }).ToList();
            return View(recordsModel);

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                CreationDate = DateTime.Now,
                ParentModelId = model.ParentModelId,
                BrandId = model.BrandId,
            };

            var client = new HttpClient();
            var jsonContent=JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7137/api/Model/SetModel", content);

            //await _modelAppService.Set(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var models = await _modelAppService.GetAll();
            ViewBag.Models = models.Where(x => x.Id != id).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            var dto = await _modelAppService.Get(id);
            var viewModel = new ModelUpdateViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IsDeleted = dto.IsDeleted,
                BrandId = dto.BrandId,
                ParentModelId = dto.ParentModelId
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ModelUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                IsDeleted = model.IsDeleted,
                BrandId = model.BrandId,
                ParentModelId = model.ParentModelId
            };
            await _modelAppService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _modelAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<bool> CheckName(string name)
        {
            try
            {
                await _modelAppService.Get(name);
                return false;
            }
            catch (Exception)
            {
                return true;
            }

        }
    }
}
