using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;
public class ColorCommandRepository : IColorCommandRepository
{
    private readonly AppDbContext _context;

    public ColorCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddColor(string name, string ColorCode, DateTime creationDate, bool isDeleted = false)
    {
        Color color = new()
        {
            Name = name,
            Code = ColorCode,
            CreationDate = creationDate,
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

    public void UpdateColor(int id, string name, string ColorCode)
    {
        var color = _context.Colors.Where(p => p.Id == id).Single();
        color.Name = name;
        color.Code = ColorCode;
        _context.SaveChanges();
    }
}
