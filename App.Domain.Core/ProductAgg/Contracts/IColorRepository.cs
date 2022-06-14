
using App.Domain.Core.ProductAgg.Entities;

namespace App.Domain.Core.ProductAgg.Contracts
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