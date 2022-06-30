using App.Domain.Core.Product.Contacts.Repositories.PFile;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.PFile
{
    public class PFileQueryRepository : IPFileQueryRepository
    {
        private readonly AppDbContext _context;

        public PFileQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<PFileDto>> GetAll()
        {
            return await _context.PFiles.Select(p => new PFileDto()
            {
                Id = p.Id,
                FileName = p.FileName,
                Size = p.Size,
                ProductId = p.ProductId,

            }).ToListAsync();
        }

        public async Task<PFileDto>? Get(int id)
        {
            var record = await _context.PFiles.Where(p => p.Id == id).Select(p => new PFileDto()
            {
                Id = p.Id,
                FileName = p.FileName,
                Size = p.Size,
                ProductId = p.ProductId,
            }).SingleOrDefaultAsync();
            return record;
        }

        public async Task<PFileDto>? Get(string name)
        {
            var record = await _context.PFiles.Where(p => p.FileName == name).Select(p => new PFileDto()
            {
                Id = p.Id,
                FileName = p.FileName,
                Size = p.Size,
                ProductId = p.ProductId,
            }).SingleOrDefaultAsync();
            return record;
        }
    }
}
