using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(ProductDto product)
        {
            var productt = new App.Domain.Core.Product.Entities.Product()
            {
                Id = product.Id,
                Name = product.Name,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelId = product.ModelId,
                Description = product.Description,
                CreationDate = product.CreationDate,
                IsDeleted = product.IsDeleted,
                Count = product.Count,
                IsActive = product.IsActive,
                IsOrginal = product.IsOrginal,
                IsShowPrice = product.IsShowPrice,
                OperatorId = product.OperatorId,
                Price = product.Price,
                Weight = product.Weight
            };
            _appDbContext.Add(productt);
            await _appDbContext.SaveChangesAsync();
            var id = productt.Id;
            return id;
        }

        public async Task Remove(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(ProductDto product)
        {
            var productt = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            productt.Name = product.Name;
            productt.BrandId = product.BrandId;
            productt.CategoryId = product.CategoryId;
            productt.ModelId = product.ModelId;
            productt.Description = product.Description;
            productt.CreationDate = product.CreationDate;
            productt.IsDeleted = product.IsDeleted;
            productt.Count = product.Count;
            productt.IsActive = product.IsActive;
            productt.IsOrginal = product.IsOrginal;
            productt.IsShowPrice = product.IsShowPrice;
            productt.OperatorId = product.OperatorId;
            productt.Price = product.Price;
            productt.Weight = product.Weight;
            await _appDbContext.SaveChangesAsync();
        }
    }
}