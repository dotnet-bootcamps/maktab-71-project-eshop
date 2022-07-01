using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Dtos.Color;
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
                Id = p.Id,
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
                Id = p.Id,
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
                Id = p.Id,
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

        public async Task<List<ProductBriefDto>?> Search(int? categoryId, string? keyword, int? minPrice, int? maxPrice, int? brandId,CancellationToken cancellationToken)
        {
            var tt= await _context.Products.AsNoTracking()
                .Where(p => (categoryId == null || p.CategoryId == categoryId))
                .Where(p => (minPrice == null || p.Price >= minPrice))
                .Where(p => (maxPrice == null || p.Price <= maxPrice))
                .Where(p => (keyword == null || keyword =="" || p.Description.Contains(keyword) || p.Name.Contains(keyword)))
                .Select(p=> new ProductBriefDto()
                {
                    Id=p.Id,
                    Name=p.Name,
                    BrandName=p.Brand.Name,
                    CategoryName=p.Category.Name,
                    Price=p.Price,
                    IsOrginal=p.IsOrginal,
                    Count=p.Count,
                    Colors=p.ProductColors.Select(c=> new ColorDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code=c.Color.Code,
                        CreationDate=c.CreationDate,
                        IsDeleted=c.IsDeleted,
                    }).ToList(),
                    Files=p.ProductFiles.Select(f=> new ProductFileDto()
                    {
                        Id=f.Id,
                        Name=f.Name,
                        FileTypeId=f.FileTypeId,
                        CreationDate=f.CreationDate,
                        IsDeleted=f.IsDeleted,
                        ProductId=f.ProductId,
                    }).ToList(),
                }).ToListAsync(cancellationToken);

            return tt;
        }
    }
}
