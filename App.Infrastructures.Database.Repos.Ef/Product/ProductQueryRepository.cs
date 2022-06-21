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

        public async Task<ProductOutputDto?> Get(int id)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Id == id).Select(p => new ProductOutputDto()
            {
                Id = p.Id,
                Name = p.Name,
                BrandId = p.BrandId,
                Brand = p.Brand.Name,
                CategoryId = p.CategoryId,
                Category = p.Category.Name,
                Count = p.Count,
                CreationDate = p.CreationDate,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                Model = p.Model.Name,
                Operator = p.Operator.Name,
                OperatorId = p.OperatorId,
                Price = p.Price,
                Weight = p.Weight
            }).FirstOrDefaultAsync();
        }

        public async Task<ProductOutputDto?> Get(string name)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Name == name).Select(p => new ProductOutputDto()
            {
                Id = p.Id,
                Name = p.Name,
                BrandId = p.BrandId,
                Brand = p.Brand.Name,
                CategoryId = p.CategoryId,
                Category = p.Category.Name,
                Count = p.Count,
                CreationDate = p.CreationDate,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                Model = p.Model.Name,
                Operator = p.Operator.Name,
                OperatorId = p.OperatorId,
                Price = p.Price,
                Weight = p.Weight
            }).FirstOrDefaultAsync();
        }

        public async Task<ProductOutputDto?> Get(int modelId, int categoryId, int brandId)
        {
            return await _context.Products.AsNoTracking()
                .Where(p => p.ModelId == modelId && p.CategoryId == categoryId && p.BrandId == brandId)
                .Select(p => new ProductOutputDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandId = p.BrandId,
                    Brand = p.Brand.Name,
                    CategoryId = p.CategoryId,
                    Category = p.Category.Name,
                    Count = p.Count,
                    CreationDate = p.CreationDate,
                    Description = p.Description,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted,
                    IsOrginal = p.IsOrginal,
                    IsShowPrice = p.IsShowPrice,
                    ModelId = p.ModelId,
                    Model = p.Model.Name,
                    Operator = p.Operator.Name,
                    OperatorId = p.OperatorId,
                    Price = p.Price,
                    Weight = p.Weight
                }).FirstOrDefaultAsync();
        }

        public async Task<List<ProductOutputDto>> GetAll()
        {
            return await _context.Products.AsNoTracking().Select(p => new ProductOutputDto()
            {
                Id = p.Id,
                Name = p.Name,
                BrandId = p.BrandId,
                Brand = p.Brand.Name,
                CategoryId = p.CategoryId,
                Category = p.Category.Name,
                Count = p.Count,
                CreationDate = p.CreationDate,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                Model = p.Model.Name,
                Operator = p.Operator.Name,
                OperatorId = p.OperatorId,
                Price = p.Price,
                Weight = p.Weight
            }).ToListAsync();
        }
    }
}
