using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _context;

        public ColorCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddColor(string name,string code , DateTime creationDate, bool isDeleted)
        {
            Color color = new()
            {
                Name = name,
                Code = code,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            await _context.AddAsync(color);
            await _context.SaveChangesAsync();
        }

        public void DeleteColor(int id)
        {
            var color = _context.Colors.Where(p => p.Id == id).Single();
            _context.Remove(color);
            _context.SaveChanges();
        }

        public void UpdateColor(int id, string name , string code)
        {
            var color = _context.Colors.Where(p => p.Id == id).Single();
            color.Name = name;
            color.Code = code;
            _context.SaveChanges();
        }
    }
}
