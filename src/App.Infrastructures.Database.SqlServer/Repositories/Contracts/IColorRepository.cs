using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.ViewModels.Color;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IColorRepository
    {
        void Create(ColorSaveViewModel model);
        void Delete(int id);
        void Update(ColorSaveViewModel model);
        List<ColorListViewModel> GetAll();
        ColorSaveViewModel GetById(int id);
    }
}