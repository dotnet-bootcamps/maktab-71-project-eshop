using App.Domain.Core.Product.Contacts.Repositories;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(int categoryId, int brandId, decimal weight, bool isOrginal, string description,
            int Count, int modelId, long price, bool isShowPrice, bool isActive, int operatorId, string name,
            DateTime creationDate, bool isDeleted)
        {
            Domain.Core.Product.Entities.Product product = new()
            {
                CategoryId = categoryId,
                BrandId = brandId,
                Weight = weight,
                IsOrginal = isOrginal,
                Description = description,
                ModelId = modelId,
                Price = price,
                IsActive = isActive,
                OperatorId = operatorId,
                Name = name,
                CreationDate = creationDate,
                IsDeleted = isDeleted,
                Count = Count,
                IsShowPrice = isShowPrice,
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(int id, int categoryId, int brandId, decimal weight, bool isOrginal,
            string description, int Count, int modelId, long price, bool isShowPrice, bool isActive, int operatorId,
            string name, DateTime creationDate, bool isDeleted)
        {
            var product=_context.Products.Find(id);
            product.CategoryId = categoryId;
            product.BrandId = brandId;
            product.Weight = weight;
            product.IsOrginal = isOrginal;
            product.Description = description;
            product.IsActive = isActive;
            product.OperatorId = operatorId;
            product.Name = name;
            product.CreationDate = creationDate;
            product.IsDeleted = isDeleted;

        } 
    }
}