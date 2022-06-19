using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Category GetById(int Id);
        Category GetByName(string name);
        List<Category> GetAll();
        int Create(Category model);
        void Update(Category model);
        bool Remove(int Id);
    }
}
