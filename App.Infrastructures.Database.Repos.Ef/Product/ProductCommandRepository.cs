using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = App.Domain.Core.Product.Entities;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProduct(ProductDto model)
        {
            ProductEntity.Product product = new()
            {
                Name = model.Name,
                Weight = model.Weight,
                IsOrginal = model.IsOrginal,
                Description=model.Description,
                Count = model.Count,
                Price = model.Price,
                IsShowPrice = model.IsShowPrice,
                IsActive = model.IsActive,
                CreationDate = model.CreationDate,
                IsDeleted = model.IsDeleted

            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).Single();
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDto model)
        {
            var product =  _context.Products.Where(p => p.Id == model.Id).Single();
            product.Name = model.Name;
            product.Weight = model.Weight;
            product.IsOrginal = model.IsOrginal;
            product.Description = model.Description;
            product.Count = model.Count;
            product.Price = model.Price;
            product.IsShowPrice = model.IsShowPrice;
            product.IsActive = model.IsActive;
            product.CreationDate = model.CreationDate;
            product.IsDeleted = model.IsDeleted;
           await _context.SaveChangesAsync();
        }
    }
}
