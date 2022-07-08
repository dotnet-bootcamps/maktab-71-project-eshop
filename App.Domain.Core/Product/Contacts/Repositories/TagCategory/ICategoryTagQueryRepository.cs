using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories.TagCategory;

public interface ICategoryTagQueryRepository
{
    Task<List<TagDto>> getTags(int categoryId);
}