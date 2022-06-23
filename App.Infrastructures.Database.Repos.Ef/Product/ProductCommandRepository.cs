using App.Domain.Core.Product.Contarcts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductCommandRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProduct(ProductDTO model)
        {
            App.Domain.Core.Product.Entities.Product pr = new Domain.Core.Product.Entities.Product()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = model.CreationDate,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,
            };
            await _dbContext.Products.AddAsync(pr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductDTO model)
        {
            App.Domain.Core.Product.Entities.Product pr = new Domain.Core.Product.Entities.Product()
            {
                Id = model.Id
            };
            _dbContext.Products.Remove(pr);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDTO model)
        {
            App.Domain.Core.Product.Entities.Product pr = new Domain.Core.Product.Entities.Product()
            {
                Id = model.Id,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                OperatorId = 1,
                ModelId = model.ModelId,
                Count = model.Count,
                Weight = model.Weight,
                CreationDate = DateTime.Now,
                Description = model.Description,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                IsOrginal = model.IsOrginal,
                Name = model.Name,
                IsShowPrice = model.IsShowPrice,
                Price = model.Price,
            };
             _dbContext.Products.Update(pr);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
