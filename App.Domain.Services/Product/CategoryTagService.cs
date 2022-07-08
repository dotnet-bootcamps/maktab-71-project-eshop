using App.Domain.Core.Product.Contacts.Repositories.Category;
using App.Domain.Core.Product.Contacts.Repositories.TagCategory;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Services.Product
{
    public class CategoryTagService: ICategoryTagService
    {
        private readonly ICategoryTagQueryRepository _categoryTagQueryRepository;

        public CategoryTagService(ICategoryTagQueryRepository categoryTagQueryRepository)
        {
            _categoryTagQueryRepository = categoryTagQueryRepository;
        }

        public async Task<List<TagDto>> GetTags(int categoryId)
        {
            return await _categoryTagQueryRepository.getTags(categoryId);
        }
    }
}
