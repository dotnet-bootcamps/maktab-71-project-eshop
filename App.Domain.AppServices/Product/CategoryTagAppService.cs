using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.AppServices.Product;

public class CategoryTagAppService:ICategoryTagAppService
{
    private readonly ICategoryTagService _categoryTagService;

    public CategoryTagAppService(ICategoryTagService categoryTagService)
    {
        _categoryTagService = categoryTagService;
    }

    public async Task<List<TagDto>> getTags(int categoryId)
    {
        return await _categoryTagService.GetTags(categoryId);
    }
}