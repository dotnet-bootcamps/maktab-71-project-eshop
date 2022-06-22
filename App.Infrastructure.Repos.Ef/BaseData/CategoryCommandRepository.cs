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
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public  async Task<int> Add(string name, int displayOrder, DateTime creationDate, int ParentCagetoryId, bool isDeleted, bool isActive)
        {
            var category = new Category()
            {
                Name = name,
                DisplayOrder = displayOrder,
                CreationDate = creationDate,
                ParentCagetoryId = ParentCagetoryId,
                IsDeleted = isDeleted,
                IsActive = isActive
            };
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task Remove(int id)
        {
            var category =await _appDbContext.Categories.SingleAsync(x => x.Id == id);
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int displayOrder, int ParentCagetoryId, bool isDeleted, bool isActive)
        {
            var category = await _appDbContext.Categories.SingleAsync(x => x.Id == id);
            category.Name = name;
            category.DisplayOrder = displayOrder;
            category.ParentCagetoryId = ParentCagetoryId;
            category.IsDeleted = isDeleted;
            category.IsActive = isActive;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
