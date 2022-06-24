using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await _context.Products.AsNoTracking().Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Count = x.Count,
                Description = x.Description,
                IsOrginal = x.IsOrginal,
                IsActive = x.IsActive,
                Weight = x.Weight,
                Price = x.Price,
                ModelId = x.ModelId,
                OperatorId = x.OperatorId,
                IsDeleted = x.IsDeleted,
                IsShowPrice = x.IsShowPrice
            }).ToListAsync();
        }

        public ProductDto? GetProductBy(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.Id == id).Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Count = x.Count,
                Description = x.Description,
                IsOrginal = x.IsOrginal,
                IsActive = x.IsActive,
                Weight = x.Weight,
                Price = x.Price,
                ModelId = x.ModelId,
                OperatorId = x.OperatorId,
                IsDeleted = x.IsDeleted,
                IsShowPrice = x.IsShowPrice
            }).FirstOrDefault();
        }

        public ProductDto? GetProductBy(string name)
        {
            return _context.Products.AsNoTracking().Where(x => x.Name == name).Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Count = x.Count,
                Description = x.Description,
                IsOrginal = x.IsOrginal,
                IsActive = x.IsActive,
                Weight = x.Weight,
                Price = x.Price,
                ModelId = x.ModelId,
                OperatorId = x.OperatorId,
                IsDeleted = x.IsDeleted,
                IsShowPrice = x.IsShowPrice
            }).FirstOrDefault();
        }
    }
}
