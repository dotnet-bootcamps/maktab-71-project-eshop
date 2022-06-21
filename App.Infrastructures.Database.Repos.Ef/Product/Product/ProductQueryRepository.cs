using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> GetAll()
        {
            return await _context.Products.Select(p => new ProductDto()
            {
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate
            }).ToListAsync();
        }

        public async Task<ProductDto>? Get(int id)
        {
            var record = await _context.Products.Where(p => p.Id == id).Select(p => new ProductDto()
            {
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate
            }).SingleOrDefaultAsync();
            return record;
        }

        public async Task<ProductDto>? Get(string name)
        {
            var record = await _context.Products.Where(p => p.Name == name).Select(p => new ProductDto()
            {
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                ModelId = p.ModelId,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                OperatorId = p.OperatorId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                CreationDate = p.CreationDate
            }).SingleOrDefaultAsync();
            return record;
        }
    }
}
