using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
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
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductCommandRepository(AppDbContext context, IProductQueryRepository productQueryRepository)
        {
            _context = context;
            _productQueryRepository = productQueryRepository;
        }
        public async Task<int> Add(ProductDto dto)
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
            foreach (var color in dto.Colors)
            {
                ProductColor productColor = new ProductColor
                {

                    ProductId = record.Id,
                    ColorId = color.Id,
                    Name = color.Name + record.Name,
                    CreationDate = DateTime.Now,
                    IsDeleted = false,
                };
                record.ProductColors.Add(productColor);
            }

            try
            {
                await _context.AddAsync(record);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Product registration has failed");
            }

            return record.Id;
        }

        public async Task addProductFiles(List<ProductFileDto> dto,int productId)
        {
            foreach (var file in dto)
            {
                var fileTypeId = await _productQueryRepository.GetFileTypeExtentionId(file.FileType);
                ProductFile productFile = new ProductFile
                {
                    FileTypeId = fileTypeId,
                    ProductId = productId,
                    Name = file.Name,
                    CreationDate = DateTime.Now,
                    IsDeleted = false,
                };
                _context.ProductFiles.Add(productFile);
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
                    Name = color.Name + record.Name,
                    CreationDate = DateTime.Now,
                    IsDeleted = false,
                };
                productColors.Add(productColor);
            }
            record.ProductColors = productColors;
            await _context.SaveChangesAsync();
        }
    }
}
