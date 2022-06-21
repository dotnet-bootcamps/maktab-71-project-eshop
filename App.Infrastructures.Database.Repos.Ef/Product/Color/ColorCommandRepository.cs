using App.Domain.Core.Product.Contacts.Repositories.Color;
using App.Domain.Core.Product.Dtos.Color;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Color
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _context;

        public ColorCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(ColorDto dto)
        {
            App.Domain.Core.Product.Entities.Color record = new()
            {
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
                Code = dto.Code,
            };
            await _context.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var record = await _context.Colors.Where(p => p.Id == id).SingleAsync();
            _context.Remove(record!);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ColorDto dto)
        {
            var record = await _context.Colors.Where(p => p.Id == dto.Id).SingleAsync();
            record.Name = dto.Name;
            record.CreationDate = dto.CreationDate;
            record.IsDeleted = dto.IsDeleted;
            record.Code = dto.Code;
            await _context.SaveChangesAsync();
        }
    }
}
