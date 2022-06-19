
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;
public class BrandQueryRepository : IBrandQueryRepository
{
    private readonly AppDbContext _context;

    public BrandQueryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<BrandDto>> GetAllBrands()
    {
        return await _context.Brands.AsNoTracking().Select(p => new BrandDto()
        {
            Id = p.Id,
            Name = p.Name,
            DisplayOrder = p.DisplayOrder,
            CreationDate = p.CreationDate,
            IsDeleted = p.IsDeleted,
        }).ToListAsync();
    }

    public BrandDto? GetBrand(int id)
    {
        return _context.Brands.AsNoTracking().Where(p => p.Id == id).Select(p => new BrandDto()
        {
            Id = p.Id,
            DisplayOrder = p.DisplayOrder,
            CreationDate = p.CreationDate,
            Name = p.Name,
            IsDeleted = p.IsDeleted,
        }).FirstOrDefault();
     
    }

    public BrandDto? GetBrand(string name)
    {
        return _context.Brands.AsNoTracking().Where(p => p.Name == name).Select(p => new BrandDto()
        {
            Id = p.Id,
            DisplayOrder = p.DisplayOrder,
            CreationDate = p.CreationDate,
            Name = p.Name,
            IsDeleted = p.IsDeleted,
        }).SingleOrDefault();
    }
}
