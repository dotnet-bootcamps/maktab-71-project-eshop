using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class TagCommandRepository : ITagCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public TagCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }        

        public async Task<int> Add(string name, int tagCategoryId, bool hasValue, DateTime creationDate, bool isDeleted)
        {
            var tag = new Tag()
            {
                Name = name,
                CreationDate = creationDate,
                IsDeleted = isDeleted,
                HasValue = hasValue,
                TagCategoryId = tagCategoryId
            };
            _appDbContext.Tags.Add(tag);
            await _appDbContext.SaveChangesAsync();
            return tag.Id;
        }

        public async Task Remove(int id)
        {
            var tag = await _appDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Tags.Remove(tag);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted)
        {
            var model = await _appDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            model.Name = name;
            model.IsDeleted = isDeleted;
            model.TagCategoryId = tagCategoryId;
            model.HasValue = hasValue;
            await _appDbContext.SaveChangesAsync();
        }        

        
    }
}
