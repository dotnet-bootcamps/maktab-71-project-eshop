using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

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
            await _context.Products.AddAsync(record);
            await _context.SaveChangesAsync();
            foreach (var color in dto.Colors)
            {
                ProductColor productColor = new ProductColor
                {
                    ProductId = record.Id,
                    ColorId = color.Id,
                };
                record.ProductColors.Add(productColor);
            }
            foreach (var file in dto.Files)
            {
                ProductFile productFile = new ProductFile
                {
                    ProductId = record.Id,
                    FileTypeId = file.Id
                };
                record.ProductFiles.Add(productFile);

            }
            foreach (var tag in dto.Tags)
            {
                ProductTag productTag = new ProductTag
                {
                    ProductId = record.Id,
                    Name = tag.Name,
                    Value = tag.Value,
                    TagId = tag.TagId
                };
                record.ProductTags.Add(productTag);

            }
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
            var record = await _context.Products.Where(p => p.Id == dto.Id).Include(x => x.ProductColors).SingleAsync();
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
            var productColors = new List<ProductColor>();
            foreach (var color in dto.Colors)
            {
                ProductColor productColor = new ProductColor
                {

                    ProductId = record.Id,
                    ColorId = color.Id,
                };
                productColors.Add(productColor);
            }
            record.ProductColors = productColors;
            await _context.SaveChangesAsync();
        }
    }
}
