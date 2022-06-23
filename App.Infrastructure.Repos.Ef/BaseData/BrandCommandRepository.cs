using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class BrandCommandRepository :IBrandCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrandCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(string name, int displayOrder, DateTime creationDate, bool isDeleted)
        {
            var brand=new Brand()
            {
                Name = name,
                DisplayOrder = displayOrder,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            _appDbContext.Brands.Add(brand);
            await _appDbContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task Remove(int id)
        {
            var brand=_appDbContext.Brands.Single(p=>p.Id == id);
            _appDbContext.Brands.Remove(brand);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int displayOrder)
        {
            var brand = _appDbContext.Brands.Single(p => p.Id == id);
            brand.Name = name;
            brand.DisplayOrder = displayOrder;
            await _appDbContext.SaveChangesAsync();
        }
    }
    }

