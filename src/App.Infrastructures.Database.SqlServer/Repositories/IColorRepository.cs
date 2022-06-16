using App.Domain.Core.BaseDataAgg.Entities;

namespace App.Infrastructures.Database.SqlServer.Ripository
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