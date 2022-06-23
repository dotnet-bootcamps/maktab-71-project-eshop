using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class CategoryCommandRepository: ICategoryCommandRepository
    {
        private readonly AppDbContext _context;

        public CategoryCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(string name, int displayOrder, int ParentCagetoryId, DateTime creationDate, bool isDeleted)
        {
            Category category = new()
            {
                Name = name,
                DisplayOrder = displayOrder,
                CreationDate = creationDate,
                ParentCagetoryId=ParentCagetoryId,
                IsDeleted = isDeleted
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Where(p => p.Id == id).Single();
            _context.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(int id, string name, int ParentCagetoryId, int displayOrder)
        {
            var category = _context.Categories.Where(p => p.Id == id).Single();
            category.Name = name;
            category.DisplayOrder = displayOrder;
            category.ParentCagetoryId = ParentCagetoryId;
            _context.SaveChanges();
        }
    }
}
