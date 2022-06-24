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
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _context;
        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Get(int id)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Id == id).Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).FirstOrDefaultAsync();
        }

        public async Task<ProductDto> Get(string name)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Name == name).Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).SingleOrDefaultAsync();
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return await _context.Products.AsNoTracking().Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                Count = p.Count,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                IsActive = p.IsActive,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).ToListAsync();
        }
    }
}
