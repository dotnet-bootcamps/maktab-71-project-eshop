using App.Domain.Core.Product.Contacts.Repositories;
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
    public class ProductQueryRepository: IProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await _context.Products.AsNoTracking().Select(p => new ProductDto()
            {
                Id = p.Id,
                Category = p.Category,
                CategoryId = p.CategoryId,
                Brand = p.Brand,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ProductModel = p.Model,
                ProductModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).ToListAsync();
        }

        public ProductDto? GetProduct(int id)
        {
            return _context.Products.AsNoTracking().Where(p => p.Id == id).Select(p => new ProductDto()
            {
                Id = p.Id,
                Category = p.Category,
                CategoryId = p.CategoryId,
                Brand = p.Brand,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ProductModel = p.Model,
                ProductModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).FirstOrDefault();
        }

        public ProductDto? GetProduct(string name)
        {
            return _context.Products.AsNoTracking().Where(p => p.Name == name).Select(p => new ProductDto()
            {
                Id = p.Id,
                Category = p.Category,
                CategoryId = p.CategoryId,
                Brand = p.Brand,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ProductModel = p.Model,
                ProductModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).FirstOrDefault();
        }
    }
}
