using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ModelCommandRepository : IModelCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(string name, int parentModelId, int brandId, DateTime creationDate, bool isDeleted)
        {
            var model = new Model()
            {
                Name = name,
                CreationDate = creationDate,
                IsDeleted = isDeleted,
                BrandId = brandId,
                ParentModelId = parentModelId                
            };
            _appDbContext.Models.Add(model);
            await _appDbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task Remove(int id)
        {
            var model = await _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Models.Remove(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted)
        {
            var model = await _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == id);
            model.Name = name;
            model.IsDeleted = isDeleted;
            model.ParentModelId = parentModelId;
            model.BrandId = brandId;
            await _appDbContext.SaveChangesAsync();
        }   
    }
}
