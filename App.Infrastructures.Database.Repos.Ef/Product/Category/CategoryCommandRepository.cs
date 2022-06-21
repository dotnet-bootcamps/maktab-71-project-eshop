using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Category
{
    public class CategoryCommandRepository
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

        public void Delete(int id)
        {
            try
            {
                var category = _context.Categories.Where(p => p.Id == id).SingleOrDefault();

                _context.Remove(category!);
                _context.SaveChanges();
            }
            catch (Exception dbx)
            {

                throw new Exception(dbx.Message, dbx.InnerException);
            }                
        }

        public void Update(CategoryDto dto)
        {
            var category = _context.Categories.Where(p => p.Id == dto.Id).Single();
            category.Name = dto.Name;
            category.CreationDate = dto.CreationDate;
            category.IsDeleted = dto.IsDeleted;
            category.IsActive = dto.IsActive;
            category.ParentCagetoryId = dto.ParentCagetoryId;
            category.DisplayOrder = dto.DisplayOrder;
            _context.SaveChanges();
        }
    }
}
