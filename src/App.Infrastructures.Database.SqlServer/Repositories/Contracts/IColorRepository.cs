using App.Domain.Core.BaseData_Aggregate.Entities;

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