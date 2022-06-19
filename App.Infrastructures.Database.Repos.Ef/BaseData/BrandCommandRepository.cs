using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;
public class BrandCommandRepository : IBrandCommandRepository
{
    private readonly AppDbContext _context;

    public BrandCommandRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddBrand(string name, int displayOrder, DateTime creationDate, bool isDeleted)
    {
        Brand brand = new()
        {
            Name = name,
            DisplayOrder = displayOrder,
            CreationDate = creationDate,
            IsDeleted = isDeleted
        };
        await _context.AddAsync(brand);
        await _context.SaveChangesAsync();
    }

    public void DeleteBrand(int id)
    {
        var brand = _context.Brands.Where(p => p.Id == id).Single();
        _context.Remove(brand);
        _context.SaveChanges();
    }

    public void UpdateBrand(int id, string name, int displayOrder)
    {
        var brand = _context.Brands.Where(p => p.Id == id).Single();
        brand.Name = name;
        brand.DisplayOrder = displayOrder;
        _context.SaveChanges();
    }
}
