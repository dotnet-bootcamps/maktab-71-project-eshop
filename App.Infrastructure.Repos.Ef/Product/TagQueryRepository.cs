using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class TagQueryRepository : ITagQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public TagQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<TagDto?> Get(int id)
        {
            var tag = await _appDbContext.Tags.Where(x => x.Id == id)
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate,
                    HasValue=x.HasValue,
                    TagCategoryId = x.TagCategoryId
                }).FirstOrDefaultAsync();
            return tag;
        }

        public async Task<TagDto?> Get(string name)
        {
            var tag = await _appDbContext.Tags.Where(x => x.Name == name)
                .Select(x => new TagDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate,
                    HasValue = x.HasValue,
                    TagCategoryId = x.TagCategoryId
                }).SingleOrDefaultAsync();
            return tag;
        }

        public async Task<List<TagDto>> GetAll()
        {
            var tags = await _appDbContext.Tags.Select(x => new TagDto()
            {
                Id = x.Id,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate,
                HasValue = x.HasValue,
                TagCategoryId = x.TagCategoryId
            }).ToListAsync();
            return tags;
        }
    }
}
