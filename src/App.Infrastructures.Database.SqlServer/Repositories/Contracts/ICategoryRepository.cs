using App.Domain.Core.Product.Entities;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
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
