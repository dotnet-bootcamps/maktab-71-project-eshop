using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product;

public class CategoryQueryRepository : ICategoryQueryRepository
{
    private readonly AppDbContext _context;
    public CategoryQueryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> GetAllCategory()
    {
        return await _context.Categories.AsNoTracking().Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate,
            IsDeleted = x.IsDeleted,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive,
            ParentCagetoryId = x.ParentCagetoryId
        }).ToListAsync();
    }

    public CategoryDto? GetCategoryBy(int id)
    {
        return _context.Categories.Where(x => x.Id == id).AsNoTracking().Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate,
            IsDeleted = x.IsDeleted,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive,
            ParentCagetoryId = x.ParentCagetoryId
        }).FirstOrDefault();
    }

    public CategoryDto? GetCategoryBy(string name)
    {
        return _context.Categories.Where(x => x.Name == name).AsNoTracking().Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name,
            CreationDate = x.CreationDate,
            IsDeleted = x.IsDeleted,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive,
            ParentCagetoryId = x.ParentCagetoryId
        }).FirstOrDefault();
    }


}