using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CategoryDto?> Get(int id)
        {
            var category = await _appDbContext.Categories.Where(x => x.Id == id).Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                DisplayOrder = x.DisplayOrder,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                ParentCagetoryId = x.ParentCagetoryId
            }).FirstOrDefaultAsync();
            return category;
        }

        public async Task<CategoryDto?> Get(string name)
        {
            var category = await _appDbContext.Categories.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                DisplayOrder = x.DisplayOrder,
                IsDeleted = x.IsDeleted,
                IsActive = x.IsActive,
                ParentCagetoryId = x.ParentCagetoryId
            }).SingleOrDefaultAsync();
            return category;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var brands = await _appDbContext.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                ParentCagetoryId = x.ParentCagetoryId,
                DisplayOrder = x.DisplayOrder,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted
            }).ToListAsync();
            return brands;
        }
    }
}


