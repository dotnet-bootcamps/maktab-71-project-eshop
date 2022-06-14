using categoryEntities = App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface ICategoryRepository
    {
        categoryEntities.Category GetBy(int Id);
        List<categoryEntities.Category> GetAll();
        void Create(categoryEntities.Category brand);
        void Update(categoryEntities.Category brand);
        void Remove(int Id);
    }
}
