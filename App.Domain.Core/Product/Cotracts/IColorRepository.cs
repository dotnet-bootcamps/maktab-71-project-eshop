using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts
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