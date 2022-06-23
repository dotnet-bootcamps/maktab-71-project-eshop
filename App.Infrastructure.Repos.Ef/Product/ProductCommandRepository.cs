using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        
    }
}