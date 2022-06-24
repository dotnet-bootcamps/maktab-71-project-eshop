using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorQueryRepository : IColorQueryRepository
    {
        private readonly AppDbContext _context;
        public ColorQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ColorDto> Get(int id)
        {
            return await _context.Colors.AsNoTracking().Select(p => new ColorDto()
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).FirstOrDefaultAsync();
        }

        public async Task<ColorDto> Get(string code)
        {
            return await _context.Colors.AsNoTracking().Where(p => p.Code == code).Select(p => new ColorDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                Code=p.Code,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefaultAsync();

        }

        public async Task<List<ColorDto>> GetAll()
        {
            return await _context.Colors.AsNoTracking().Select(p => new ColorDto()
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToListAsync();
        }
    }
}


