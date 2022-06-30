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
    public class PFileCommandRepository : IPFileCommandRepository
    {
        private readonly AppDbContext _context;

        public PFileCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(PFileDto dto)
        {
            App.Domain.Core.Product.Entities.PFile record = new()
            {
                FileName = dto.FileName,
                Size = dto.Size,
                ProductId = dto.ProductId,
            };
            await _context.PFiles.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var record = await _context.PFiles.Where(p => p.Id == id).SingleAsync();
            _context.Remove(record!);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PFileDto dto)
        {
            var record = await _context.PFiles.Where(p => p.Id == dto.Id).SingleAsync();
            record.FileName = dto.FileName;
            record.Size = dto.Size;

            await _context.SaveChangesAsync();
        }
    }
}
