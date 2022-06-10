using App.Infrastructures.Database.SqlServer.Entities;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
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
