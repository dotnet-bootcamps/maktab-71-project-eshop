using App.Infrastructures.Database.SqlServer.Entities;

namespace App.Infrastructures.Database.SqlServer.Ripository
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(int id);
        void Edit(Product model);
        List<Product> GetAll();
        Product GetById(int id);
    }
}