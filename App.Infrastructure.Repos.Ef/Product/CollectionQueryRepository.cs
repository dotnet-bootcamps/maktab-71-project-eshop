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
    public class CollectionQueryRepository : ICollectionQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CollectionQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<CollectionDto?> Get(int id)
        {
            var collection = await _appDbContext.Collections.Where(x => x.Id == id)
                .Select(x => new CollectionDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate
                }).FirstOrDefaultAsync();
            return collection;
        }

        public async Task<CollectionDto?> Get(string name)
        {
            var collection = await _appDbContext.Collections.Where(x => x.Name == name)
                .Select(x => new CollectionDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate
                }).SingleOrDefaultAsync();
            return collection;
        }

        public async Task<List<CollectionDto>> GetAll()
        {
            var collections = await _appDbContext.Collections.Select(x => new CollectionDto()
            {
                Id = x.Id,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate
            }).ToListAsync();
            return collections;
        }
    }
}
