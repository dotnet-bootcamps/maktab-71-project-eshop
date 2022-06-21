using App.Domain.Core.Operator.Contract.AppServices;
using App.Domain.Core.Operator.Dtos;
using App.EndPoints.Mvc.AdminUI.Models.ViewModels.Operator;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorAppService _operatorAppService;

        public OperatorController(IOperatorAppService operatorAppService)
        {
            _operatorAppService = operatorAppService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _operatorAppService.GetAll();
            var categoriesModel = categories.Select(p => new OperatorOutputViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToList();
            return View(categoriesModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperatorInputViewModel o)
        {
            var dto = new OperatorDto
            {
                Id = o.Id,
                Name = o.Name,

                IsDeleted = o.IsDeleted,

                CreationDate = DateTime.Now,
            };
            await _operatorAppService.Set(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _operatorAppService.Get(id);
            var viewModel = new OperatorInputViewModel
            {
                Id = dto.Id,
                Name = dto.Name,

                IsDeleted = dto.IsDeleted,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OperatorInputViewModel model)
        {
            var dto = new OperatorDto
            {
                Id = model.Id,
                Name = model.Name,
                IsDeleted = model.IsDeleted,
            };
            await _operatorAppService.Update(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _operatorAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
