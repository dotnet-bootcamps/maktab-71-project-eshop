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
    public class ColorQueryRepository : IColorQueryRepository
    {
        private readonly AppDbContext _context;

        public ColorQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ColorDto>> GetAll()
        {
            return await _context.Colors.Select(p => new ColorDto()
            {
                Id = p.Id,
                Code = p.Code,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted
            }).ToListAsync();
        }

        public async Task<ColorDto>? Get(int id)
        {
            var record = await _context.Colors.Where(p => p.Id == id).Select(p => new ColorDto()
            {
                Id = p.Id,
                Code = p.Code,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefaultAsync();
            return record;
        }

        public async Task<ColorDto>? Get(string name)
        {
            var record = await _context.Colors.Where(p => p.Name == name).Select(p => new ColorDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                Code = p.Code,
            }).SingleOrDefaultAsync();
            return record;
        }
    }

}
