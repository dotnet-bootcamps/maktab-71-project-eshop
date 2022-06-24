using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorQueryRepository : IColorQueryRepository
    {
        private readonly AppDbContext _context;

        public ColorQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ColorDto>> GetAllColor()
        {
            return await _context.Colors.AsNoTracking().Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                ColorCode = x.Code,
                CreationDate = x.CreationDate,
                IsDeleted = x.IsDeleted,

            }).ToListAsync();
        }

        public ColorDto? GetColorBy(int id)
        {
            return _context.Colors.AsNoTracking().Where(x => x.Id == id).Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                ColorCode = x.Code,
                IsDeleted = x.IsDeleted
                
            }).FirstOrDefault();
        }

        public ColorDto? GetColorBy(string name)
        {
            return _context.Colors.AsNoTracking().Where(x => x.Name == name).Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                ColorCode = x.Code,
                IsDeleted = x.IsDeleted

            }).FirstOrDefault();
        }
    }
}
