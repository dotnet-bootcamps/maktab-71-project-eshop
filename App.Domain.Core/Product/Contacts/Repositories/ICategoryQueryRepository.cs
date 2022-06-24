using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories;

public interface ICategoryQueryRepository
{
    Task<List<CategoryDto>> GetAllCategory();
    CategoryDto? GetCategoryBy(int id);
    CategoryDto? GetCategoryBy(string name);
}