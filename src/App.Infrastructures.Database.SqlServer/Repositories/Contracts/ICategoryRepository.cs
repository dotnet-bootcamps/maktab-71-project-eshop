using App.EndPoints.Mvc.AdminUI.Models;
using App.Infrastructures.Database.SqlServer.Entities;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        void Create(CategorySaveViewModel model);
        void Remove(int id);
        void Update(CategorySaveViewModel model);
        List<CategoryListViewModel> GetAll();
        CategorySaveViewModel GetById(int id);
    }
}
