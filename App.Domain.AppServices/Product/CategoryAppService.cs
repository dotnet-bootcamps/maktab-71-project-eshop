using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _CategoryService;

        public CategoryAppService(ICategoryService brandService)
        {
            _CategoryService = brandService;
        }

        public void DeleteCategory(int id)
        {
            _CategoryService.EnsureCategoryExist(id);
            _CategoryService.DeleteCategory(id);
        }

        public Task<List<CategoryDto>> GetCategories()
            => _CategoryService.GetCategories();

        public CategoryDto GetCategory(int id)
            => _CategoryService.GetCategory(id);

        public CategoryDto GetCategory(string name)
            => _CategoryService.GetCategory(name);

        public async Task SetCategory(string name, int displayOrder, int parentCategoryId)
        {
            _CategoryService.EnsureCategoryDoseNotExist(name);
            await _CategoryService.SetCategory(name, displayOrder, parentCategoryId);
        }

        public void UpdateCategory(int id, string name, int displayOrder, int parentCategoryId)
        {
            _CategoryService.EnsureCategoryExist(id);
            _CategoryService.UpdateCategory(id, name, displayOrder, parentCategoryId);
        }
    }
}
