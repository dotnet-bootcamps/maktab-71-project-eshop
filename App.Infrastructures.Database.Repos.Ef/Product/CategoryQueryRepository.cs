using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product
{

    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly AppDbContext _context;

        public CategoryQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _context.Categories.AsNoTracking().Select(p => new CategoryDto()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                ParentCategoryId = p.ParentCagetoryId,
                IsDeleted = p.IsDeleted,
            }).ToListAsync();
        }

        public CategoryDto? GetCategory(int id)
        {
            return _context.Categories.AsNoTracking().Where(p => p.Id == id).Select(p => new CategoryDto()
            {
                Id = p.Id,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                ParentCategoryId = p.ParentCagetoryId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).FirstOrDefault();
        }

        public CategoryDto? GetCategory(string name)
        {
            return _context.Categories.AsNoTracking().Where(p => p.Name == name).Select(p => new CategoryDto()
            {
                Id = p.Id,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                ParentCategoryId = p.ParentCagetoryId,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefault();
        }
    }
}
