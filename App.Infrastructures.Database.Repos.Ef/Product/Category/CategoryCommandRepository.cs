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
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly AppDbContext _context;

        public CategoryCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(CategoryDto dto)
        {
            App.Domain.Core.Product.Entities.Category category = new()
            {
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
                ParentCagetoryId = dto.ParentCagetoryId,
                DisplayOrder = dto.DisplayOrder,
                IsActive = dto.IsActive,
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var category = await _context.Categories.Where(p => p.Id == id).SingleAsync();

            _context.Remove(category!);
            await _context.SaveChangesAsync();           
        }

        public async Task Update(CategoryDto dto)
        {
            var category = await _context.Categories.Where(p => p.Id == dto.Id).SingleAsync();
            category.Name = dto.Name;
            category.CreationDate = dto.CreationDate;
            category.IsDeleted = dto.IsDeleted;
            category.IsActive = dto.IsActive;
            category.ParentCagetoryId = dto.ParentCagetoryId;
            category.DisplayOrder = dto.DisplayOrder;
            await _context.SaveChangesAsync();
        }
    }
}
