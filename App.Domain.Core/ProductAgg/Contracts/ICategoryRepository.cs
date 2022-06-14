using App.Domain.Core.ProductAgg.Entities;

namespace App.Domain.Core.ProductAgg.Contracts
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
