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
    public class FileTypeQueryRepository : IFileTypeQueryRepository
    {

        private readonly AppDbContext _context;

        public FileTypeQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<FileTypeDto> Get(int id)
        {
            return await _context.FileTypes.AsNoTracking().Where(p => p.Id == id).Select(p => new FileTypeDto()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).FirstOrDefaultAsync();
        }

        public async Task<FileTypeDto> Get(string name)
        {
            return await _context.FileTypes.AsNoTracking().Where(p => p.Name == name).Select(p => new FileTypeDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefaultAsync();
        }

        public async Task<List<FileTypeDto>> GetAll()
        {
            return await _context.FileTypes.AsNoTracking().Select(p => new FileTypeDto()
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted,
            }).ToListAsync();
        }
    }
}
