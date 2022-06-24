using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.Product;

public class CategoryCommandRepository: ICategoryCommandRepository
{
    private readonly AppDbContext _context;

    public CategoryCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddCategory(bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
        bool isDeleted)
    {
        Category category = new Category()
        {
            IsActive = isActive,
            DisplayOrder = displayOrder,
            CreationDate = creationDate,
            IsDeleted = isDeleted,
            Name = name,
            ParentCagetoryId = parentCagetoryId
        };
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public void UpdateCategory(int id, bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
        bool isDeleted)
    {
        var category = _context.Categories.Find(id);
        category.IsActive = isActive;
        category.DisplayOrder = displayOrder;
        category.CreationDate= creationDate;
        category.IsDeleted = isDeleted;
        category.Name = name;
        category.Id= id;

    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
}