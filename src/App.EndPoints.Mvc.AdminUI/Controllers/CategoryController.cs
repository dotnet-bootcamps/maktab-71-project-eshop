using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {
        }
        public IActionResult Index()
        {
            // TODO
            List<CategoryListVM> model = new List<CategoryListVM>();
            return View(model);
        }
        public IActionResult Add(CategorySaveVM model)
        {
            throw new NotImplementedException();
        }
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }
        public IActionResult View(int id)
        {
            CategorySaveVM vm = new CategorySaveVM();
            return View(vm);
        }
    }
}
