
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
        private readonly IConfiguration _configuration;
       

        public ModelController(IModelAppService appService, IBrandAppService brandAppService, IConfiguration configuration)
        {
            _modelAppService = appService;
            _brandAppService = brandAppService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(CancellationToken CancellationToken)
        {
            //مشاهده لیست مدل در روش MVC
            //var records = await _modelAppService.GetAll();
            //var recordsModel = records.Select(p => new ModelOutputViewModel()
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    CreationDate = p.CreationDate,
            //    IsDeleted = p.IsDeleted,
            //    ParentModelId = p.ParentModelId,
            //    BrandId = p.BrandId,
            //}).ToList();
            //return View(recordsModel);

            //مشاهده لیست مدل در روش API
            try
            {
                var client = new HttpClient();
                var request=new HttpRequestMessage(HttpMethod.Get, "https://localhost:7137/api/Product/GetAllModel");
                request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
                var response= await client.SendAsync(request, CancellationToken);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyModel = JsonConvert.DeserializeObject<List<ModelDto>>(responseBody);
                if (response.IsSuccessStatusCode == false)
                    throw new Exception("خطا در دریافت اطلاعات");
                if (responseBodyModel == null)
                {

                }
                else
                {
                    var viewmodel = responseBodyModel.Select(p => new ModelOutputViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CreationDate = p.CreationDate,
                        IsDeleted = p.IsDeleted,
                        ParentModelId = p.ParentModelId,
                        BrandId = p.BrandId,
                    }).ToList();
                    return View(viewmodel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"eror in list of model : {ex.Message}");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var models = await _modelAppService.GetAll();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7137/api/Product/GetAllModel");
                request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyModel = JsonConvert.DeserializeObject<List<ModelDto>>(responseBody);
                if (response.IsSuccessStatusCode == false)
                    throw new Exception("خطا در دریافت اطلاعات");
                if (responseBodyModel == null)
                {

                }
                else
                {
                    var viewmodel = responseBodyModel.Select(p => new ModelOutputViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CreationDate = p.CreationDate,
                        IsDeleted = p.IsDeleted,
                        ParentModelId = p.ParentModelId,
                        BrandId = p.BrandId,
                    }).ToList();
                    ViewBag.Models = viewmodel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"eror in list of model : {ex.Message}");
            }
            //return View();
          

            var brands = await _brandAppService.GetAll();
            ViewBag.Brands = brands.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(ModelAddViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var dto = new ModelDto
        //    {
        //        Id = model.Id,
        //        Name = model.Name,
        //        CreationDate = DateTime.Now,
        //        ParentModelId = model.ParentModelId,
        //        BrandId = model.BrandId,
        //    };
        //    await _modelAppService.Set(dto);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public async Task<IActionResult> Create(ModelAddViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var dto = new ProductDto
                    {
                        Id = model.Id,
                        Name = model.Name,
                        CreationDate = DateTime.Now,
                        ParentModelId = model.ParentModelId,
                        BrandId = model.BrandId,
                    };

                    using var client = new HttpClient();
                    var jsonContent = JsonConvert.SerializeObject(dto);
                    HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
                    var httpResponse = await client.PostAsync("https://localhost:7137/api/Product/SetModel", httpContent, cancellationToken);
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("خطایی در دریافت اطلاعات رخ داد.");
                    }
                    //await _productAppService.Set(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception accord", ex);
                }

            }
            else
            {
                return View(index);
            }

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
        //جلوگیری از کد تکراری که نشد
        //public async Task<List<ModelOutputViewModel>> GetallModel(CancellationToken CancellationToken)
        //{

        //    try
        //    {
        //        var client = new HttpClient();
        //        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7137/api/Product/GetAllModel");
        //        request.Headers.Add("ApiKey", _configuration.GetSection("ApiKey").Value);
        //        var response = await client.SendAsync(request, CancellationToken);
        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        var responseBodyModel = JsonConvert.DeserializeObject<List<ModelDto>>(responseBody);
        //        if (response.IsSuccessStatusCode == false)
        //            throw new Exception("خطا در دریافت اطلاعات");
        //        if (responseBodyModel == null)
        //        {

        //        }
        //        else
        //        {
        //            var viewmodel = responseBodyModel.Select(p => new ModelOutputViewModel()
        //            {
        //                Id = p.Id,
        //                Name = p.Name,
        //                CreationDate = p.CreationDate,
        //                IsDeleted = p.IsDeleted,
        //                ParentModelId = p.ParentModelId,
        //                BrandId = p.BrandId,
        //            }).ToList();
        //            return viewmodel;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"eror in list of model : {ex.Message}");

        //    }
           
        //}
}
    }



