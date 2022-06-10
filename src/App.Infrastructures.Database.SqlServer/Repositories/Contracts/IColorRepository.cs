using App.Infrastructures.Database.SqlServer.Entities;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IColorRepository
    {
        void Create(Color color);
        void Delete(int id);
        void Edit(Color model);
        List<Color> GetAll();
        Color GetById(int id);
    }
}