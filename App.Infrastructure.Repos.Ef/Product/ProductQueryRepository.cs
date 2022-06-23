using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductDto?> Get(int id)
        {
            var product = await _appDbContext.Products.Where(x => x.Id == id)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ModelId = x.ModelId,
                    Description = x.Description,
                    CreationDate = x.CreationDate,
                    IsDeleted = x.IsDeleted,
                    Count = x.Count,
                    IsActive = x.IsActive,
                    IsOrginal = x.IsOrginal,
                    IsShowPrice = x.IsShowPrice,
                    OperatorId = x.OperatorId,
                    Price = x.Price,
                    Weight = x.Weight
                }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<ProductDto?> Get(string name, int brandId, int categoryId, int modelId)
        {
            var product = await _appDbContext.Products
                .Where(x => x.Name == name && x.BrandId == brandId && x.CategoryId == categoryId && x.ModelId == modelId)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ModelId = x.ModelId,
                    Description = x.Description,
                    CreationDate = x.CreationDate,
                    IsDeleted = x.IsDeleted,
                    Count = x.Count,
                    IsActive = x.IsActive,
                    IsOrginal = x.IsOrginal,
                    IsShowPrice = x.IsShowPrice,
                    OperatorId = x.OperatorId,
                    Price = x.Price,
                    Weight = x.Weight
                })
                .SingleOrDefaultAsync();
            return product;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _appDbContext.Products                
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ModelId = x.ModelId,
                    Description = x.Description,
                    CreationDate = x.CreationDate,
                    IsDeleted = x.IsDeleted,
                    Count = x.Count,
                    IsActive = x.IsActive,
                    IsOrginal = x.IsOrginal,
                    IsShowPrice = x.IsShowPrice,
                    OperatorId = x.OperatorId,
                    Price = x.Price,
                    Weight = x.Weight
                })
                .ToListAsync();
            return products;
        }
    }
}
