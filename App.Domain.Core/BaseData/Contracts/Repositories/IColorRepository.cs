using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.BaseData.Contracts.Repositories
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