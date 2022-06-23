using System;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class CollectionCommandRepository : ICollectionCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public CollectionCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<int> Add(string name, DateTime creationDate, bool isDeleted)
        {
            var collection = new Collection()
            {
                Name = name,
                CreationDate = creationDate,
                IsDeleted = isDeleted,
            };
            _appDbContext.Collections.Add(collection);
            await _appDbContext.SaveChangesAsync();
            return collection.Id;
        }

        public async Task Remove(int id)
        {
            var collection = await _appDbContext.Collections.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Collections.Remove(collection);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, bool isDeleted)
        {
            var collection = await _appDbContext.Collections.FirstOrDefaultAsync(x => x.Id == id);
            collection.Name = name;
            collection.IsDeleted = isDeleted;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
