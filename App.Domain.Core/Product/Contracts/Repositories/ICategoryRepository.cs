using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Category GetById(int Id);
        List<Category> GetAll();
        int Create(Category model);
        void Update(Category model);
        bool Remove(int Id);
    }
}
