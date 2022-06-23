using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ProductModelQueryRepository: IProductModelQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductModelQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModelDto>> GetAllProductModel()
        {
            return await _context.Models.AsNoTracking().Select(p => new ProductModelDto()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                ParentModelId = p.ParentModelId,
                Brand=p.Brand,
                BrandId=p.BrandId,
                IsDeleted = p.IsDeleted,
            }).ToListAsync();
        }

        public ProductModelDto? GetProductModel(int id)
        {
            return _context.Models.AsNoTracking().Where(p => p.Id == id).Select(p => new ProductModelDto()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                ParentModelId = p.ParentModelId,
                Brand = p.Brand,
                BrandId = p.BrandId,
                IsDeleted = p.IsDeleted,
            }).FirstOrDefault();
        }

        public ProductModelDto? GetProductModel(string name)
        {
            return _context.Models.AsNoTracking().Where(p => p.Name == name).Select(p => new ProductModelDto()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                ParentModelId = p.ParentModelId,
                Brand = p.Brand,
                BrandId = p.BrandId,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefault();
        }
    }
}
