using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Create(Product model)
        {
            _appDbContext.Products.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;
        }
        public void Update(Product model)
        {
            var record = _appDbContext.Products.FirstOrDefault(p => p.Id == model.Id);
            record.Name = model.Name;
            record.Description = model.Description;
            record.Weight = model.Weight;
            record.Price = model.Price;
            record.Count = model.Count;
            record.IsActive = model.IsActive;
            record.CreationDate = model.CreationDate;
            _appDbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var record = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            _appDbContext.Products.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            var record = _appDbContext.Products.ToList();
            return record;
        }
        public Product GetById(int id)
        {
            var record = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            return record;
        }
    }
}