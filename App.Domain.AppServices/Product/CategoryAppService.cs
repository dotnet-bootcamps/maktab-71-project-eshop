using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.AppServices.Product;

public class CategoryAppService : ICategoryAppService
{
    public Task<List<CategoryDto>> GetCategorys()
    {
        throw new NotImplementedException();
    }

    public Task SetCategory(bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
        bool isDeleted)
    {
        throw new NotImplementedException();
    }

    public CategoryDto GetCategory(int id)
    {
        throw new NotImplementedException();
    }

    public CategoryDto GetCategory(string name)
    {
        throw new NotImplementedException();
    }

    public void UpdateCategory(int id, bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
        bool isDeleted)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}