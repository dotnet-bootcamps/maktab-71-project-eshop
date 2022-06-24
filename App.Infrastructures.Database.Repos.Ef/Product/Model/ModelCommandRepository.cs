using App.Domain.Core.Product.Contacts.Repositories.Model;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Model
{
    public class ModelCommandRepository : IModelCommandRepository
    {
        private readonly AppDbContext _context;

        public ModelCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(ModelDto dto)
        {
            App.Domain.Core.Product.Entities.Model record = new()
            {
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
                ParentModelId = dto.ParentModelId,
                BrandId = dto.BrandId,
            };
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var record = await _context.Models.Where(p => p.Id == id).SingleAsync();
            _context.Remove(record!);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ModelDto dto)
        {
            var record = await _context.Models.Where(p => p.Id == dto.Id).SingleAsync();
            record.Name = dto.Name;
            record.CreationDate = dto.CreationDate;
            record.IsDeleted = dto.IsDeleted;
            record.ParentModelId = dto.ParentModelId;
            record.BrandId = dto.BrandId;
            await _context.SaveChangesAsync();
        }
    }
}
