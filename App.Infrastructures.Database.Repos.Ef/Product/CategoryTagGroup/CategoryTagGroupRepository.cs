using App.Domain.Core.Product.Contacts.Repositories.TagCategory;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.CategoryTagGroup
{
    public class CategoryTagGroupRepository : ICategoryTagGroupRepository
    {
        private readonly AppDbContext _context;

        public CategoryTagGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagDto>> getTags(int categoryId)
        {
            List<int> tagCategoryIds = await _context.CategoryTagGroups.Where(c => c.CategoryId == categoryId).Select(x => x.TagCategoryId).ToListAsync();
            List<TagDto> tags = await _context.TagCategories.Where(t => tagCategoryIds.Contains(t.Id)).SelectMany(x => x.Tags.Select(t => new TagDto
            {
                Id = t.Id,
                Name = t.Name,
                TagCategoryId = t.TagCategoryId,
                HasValue = t.TagCategory.HasValue,
                TagCategoryName = t.TagCategory.Name,
            })).ToListAsync();
            return tags;
        }
    }
}
