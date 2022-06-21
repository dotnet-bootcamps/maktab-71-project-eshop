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
    public class CategoryQueryRepository
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
            try
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
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
            
        }

        public async Task<CategoryDto> Get(string name)
        {
            try
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
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
        }
    }
}
