
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;
public class ColorQueryRepository : IColorQueryRepository
{
    private readonly AppDbContext _context;

    public ColorQueryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ColorDto>> GetAllColors()
    {
        return await _context.Colors.AsNoTracking().Select(p => new ColorDto()
        {
            Id = p.Id,
            Name = p.Name,
            ColorCode = p.Code,
            CreationDate = p.CreationDate,
            IsDeleted = p.IsDeleted,
        }).ToListAsync();
    }

    public ColorDto? GetColor(int id)
    {
        return _context.Colors.AsNoTracking().Where(p => p.Id == id).Select(p => new ColorDto()
        {
            Id = p.Id,
            ColorCode = p.Code,
            CreationDate = p.CreationDate,
            Name = p.Name,
            IsDeleted = p.IsDeleted,
        }).FirstOrDefault();
     
    }

    public ColorDto? GetColor(string name)
    {
        return _context.Colors.AsNoTracking().Where(p => p.Name == name).Select(p => new ColorDto()
        {
            Id = p.Id,
            ColorCode = p.Code,
            CreationDate = p.CreationDate,
            Name = p.Name,
            IsDeleted = p.IsDeleted,
        }).SingleOrDefault();
    }
}
