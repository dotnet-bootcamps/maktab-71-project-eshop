using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.AppServices;

public interface ICategoryTagAppService
{
    Task<List<TagDto>> getTags(int categoryId);
}