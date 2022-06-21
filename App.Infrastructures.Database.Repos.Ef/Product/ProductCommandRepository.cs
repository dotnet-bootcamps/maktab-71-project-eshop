using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using ProductEntities = App.Domain.Core.Product.Entities;
namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductInputDto product, DateTime creationDate, bool isDeleted)
        {
            ProductEntities.Product model = new()
            {
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Count = product.Count,
                CreationDate = creationDate,
                Description = product.Description,
                IsActive = product.IsActive,
                IsDeleted = isDeleted,
                IsOrginal = product.IsOrginal,
                IsShowPrice = product.IsShowPrice,
                ModelId = product.ModelId,
                OperatorId = product.OperatorId,
                Price = product.Price,
                Weight = product.Weight,
                Name = product.Name,
            };
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, ProductInputDto product, DateTime creationDate, bool isDeleted)
        {
            ProductEntities.Product model = new()
            {
                Id=id,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Count = product.Count,
                CreationDate = creationDate,
                Description = product.Description,
                IsActive = product.IsActive,
                IsDeleted = isDeleted,
                IsOrginal = product.IsOrginal,
                IsShowPrice = product.IsShowPrice,
                ModelId = product.ModelId,
                OperatorId = product.OperatorId,
                Price = product.Price,
                Weight = product.Weight,
                Name = product.Name,
            };
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
