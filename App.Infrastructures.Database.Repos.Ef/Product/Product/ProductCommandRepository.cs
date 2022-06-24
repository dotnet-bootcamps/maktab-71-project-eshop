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
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(ProductDto dto)
        {
            App.Domain.Core.Product.Entities.Product record = new()
            {
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId,
                Weight = dto.Weight,
                IsOrginal = dto.IsOrginal,
                Description = dto.Description,
                Count = dto.Count,
                ModelId = dto.ModelId,
                Price = dto.Price,
                IsShowPrice = dto.IsShowPrice,
                IsActive = dto.IsActive,
                OperatorId = dto.OperatorId,
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
            };
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var record = await _context.Products.Where(p => p.Id == id).SingleAsync();
            _context.Remove(record!);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductDto dto)
        {
            var record = await _context.Products.Where(p => p.Id == dto.Id).SingleAsync();
                record.CategoryId = dto.CategoryId;
                record.BrandId = dto.BrandId;
                record.Weight = dto.Weight;
                record.IsOrginal = dto.IsOrginal;
                record.Description = dto.Description;
                record.Count = dto.Count;
                record.ModelId = dto.ModelId;
                record.Price = dto.Price;
                record.IsShowPrice = dto.IsShowPrice;
                record.IsActive = dto.IsActive;
                record.OperatorId = dto.OperatorId;
                record.Name = dto.Name;
                record.IsDeleted = dto.IsDeleted;
            await _context.SaveChangesAsync();
        }
    }
}
