using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ProductModelCommandRepository : IProductModelCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductModelCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProductModel(string name, int brandId, int ParentModelId, DateTime creationDate, bool isDeleted)
        {
            ProductModel productModel = new()
            {
                Name = name,
                BrandId = brandId,
                CreationDate = creationDate,
                ParentModelId = ParentModelId,
                IsDeleted = isDeleted
            };
            await _context.AddAsync(productModel);
            await _context.SaveChangesAsync();
        }


        public void DeleteProductModel(int id)
        {
            var productModel = _context.Models.Where(p => p.Id == id).Single();
            _context.Remove(productModel);
            _context.SaveChanges();
        }

        public void UpdateProductModel(int id, string name, int brandId, int ParentModelId)
        {
            var productModel = _context.Models.Where(p => p.Id == id).Single();
            productModel.Name = name;
            productModel.BrandId = brandId;
            productModel.ParentModelId = ParentModelId;
            _context.SaveChanges();
        }


    }
}
