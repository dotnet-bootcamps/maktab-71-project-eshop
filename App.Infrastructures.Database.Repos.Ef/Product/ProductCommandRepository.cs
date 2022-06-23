using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product
{

    public class ProductCommandRepository: IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(CreateProductDto command)
        {
            App.Domain.Core.Product.Entities.Product product = new()
            {
                Name = command.Name,
                CategoryId = command.CategoryId,
                BrandId = command.BrandId,
                Weight = command.Weight,
                IsOrginal = command.IsOrginal,
                Description = command.Description,
                ModelId = command.ModelId,
                Price = command.Price,
                OperatorId = 1
    };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).Single();
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(UpdateProductDto command)
        {
            var product = _context.Products.Where(p => p.Id == command.Id).Single();
            product.Name = command.Name;
            product.CategoryId = command.CategoryId;
            product.BrandId = command.BrandId;
            product.Weight = command.Weight;
            product.IsOrginal = command.IsOrginal;
            product.Description = command.Description;
            product.ModelId = command.ModelId;
            product.Price = command.Price;
            product.OperatorId = 1;
            _context.SaveChanges();
        }
    }
}
