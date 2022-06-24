using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _context;

        public ColorCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddColor(string name, string colorCode, DateTime creationDate, bool isDeleted)
        {
            Color color = new()
            {
                Name = name,
                Code = colorCode,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            await _context.AddAsync(color);
            await _context.SaveChangesAsync();
        }

        public void DeleteColor(int id)
        {
            var color = _context.Colors.Find(id);
            _context.Colors.Remove(color);
            _context.SaveChanges();
        }

        public void UpdateColor(int id, string name, string colorCode)
        {
            var color= _context.Colors.Find(id);
            color.Name = name;
            color.Code = colorCode;
            _context.SaveChanges();
        }
    }
}
