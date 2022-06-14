
using App.Domain.Core.BaseData.Entities;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IColorRepository
    {
        Color GetById(int Id);
        List<Color> GetAll();
        int Create(Color model);
        void Update(Color model);
        bool Remove(int Id);
    }
}