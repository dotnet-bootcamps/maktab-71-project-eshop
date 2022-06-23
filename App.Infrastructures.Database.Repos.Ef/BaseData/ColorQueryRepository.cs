using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorQueryRepository : IColorQueryRepository
    {
        private readonly AppDbContext _dbContext;

        public ColorQueryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ColorDTO>> GetAll()
        {
           return await _dbContext.Colors.AsNoTracking().Select(a=>new ColorDTO()
            {
                Id=a.Id,
                Name=a.Name,
                Code=a.Code,
                CreationDate=a.CreationDate,
                IsDeleted=a.IsDeleted
            }).ToListAsync();
            
        }
        public async Task<ColorDTO?> Get(int id)
        {
            return await _dbContext.Colors.AsNoTracking().Where(a => a.Id == id).Select(b=>new ColorDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Code = b.Code,
                CreationDate = b.CreationDate,
                IsDeleted = b.IsDeleted
            }).FirstOrDefaultAsync();
            
            
        }

        public async Task<ColorDTO?> Get(string name)
        {
            return await _dbContext.Colors.AsNoTracking().Where(a => a.Name == name).Select(b => new ColorDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Code = b.Code,
                CreationDate = b.CreationDate,
                IsDeleted = b.IsDeleted
            }).SingleOrDefaultAsync();
            
        }

        public ColorDTO? GetFirstOrDefault(Expression<Func<ColorDTO, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<ColorDTO> query;
            if (tracked)
            {
                //query = (IQueryable<ColorDTO>)_dbContext.Colors;
                query = _dbContext.Colors.Select(b => new ColorDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    CreationDate = b.CreationDate,
                    IsDeleted = b.IsDeleted
                });
            }
            else
            {
                query = _dbContext.Colors.AsNoTracking().Select(b => new ColorDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    CreationDate = b.CreationDate,
                    IsDeleted = b.IsDeleted
                }); ;
            }
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }


    }
}
