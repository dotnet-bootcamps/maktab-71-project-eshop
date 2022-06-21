using App.Domain.Core.Product.Contacts.Repositories.Category;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Category
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly AppDbContext _context;

        public CategoryQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            return await _context.Categories.Select(p => new CategoryDto()
            {
                Id = p.Id,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                ParentCagetoryId = p.ParentCagetoryId,
                IsActive = p.IsActive,
            }).ToListAsync();
        }

        public async Task<CategoryDto> Get(int id)
        {
            var record = await _context.Categories.Where(p => p.Id == id).Select(p => new CategoryDto()
            {
                Id = p.Id,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                ParentCagetoryId = p.ParentCagetoryId,
                IsActive = p.IsActive,             
            }).SingleOrDefaultAsync();
            if (record == null)
            {
                throw new Exception($"No Category with id : {id}!");
            }
            return record;                       
        }

        public async Task<CategoryDto> Get(string name)
        {
            var record = await _context.Categories.Where(p => p.Name == name).Select(p => new CategoryDto()
            {
                Id = p.Id,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                ParentCagetoryId = p.ParentCagetoryId,
                IsActive = p.IsActive,
            }).SingleOrDefaultAsync();
            if (record == null)
            {
                throw new Exception($"No Category with name : {name}!");
            }
            return record;
        }
    }
}
