using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Entities;
using App.EndPoints.Mvc.ShopUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryViewComponent(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IViewComponentResult Invoke()
        {
            return View("_CategoryList", _categoryAppService.GetAll().Result.Select(x=>new CategoryVM()
            {
                id = x.Id,
                name = x.Name,
                image = x.Image,
            }).ToList());
        }
    }
}
