using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts
{
    public interface ICategoryRepository
    {
        Category GetBy(int Id);
        List<Category> GetAll();
        void Create(Category brand);
        void Update(Category brand);
        void Remove(int Id);
    }
}
