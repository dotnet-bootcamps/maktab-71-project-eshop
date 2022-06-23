using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _CategoryCommandRepository;
        private readonly ICategoryQueryRepository _CategoryQueryRepository;

        public CategoryService(ICategoryCommandRepository brandCommandRepository, ICategoryQueryRepository brandQueryRepository)
        {
            _CategoryCommandRepository = brandCommandRepository;
            _CategoryQueryRepository = brandQueryRepository;
        }

        public void DeleteCategory(int id)
        {
            _CategoryCommandRepository.DeleteCategory(id);
        }

        public void EnsureCategoryDoseNotExist(string name)
        {
            var category = _CategoryQueryRepository.GetCategory(name);
            if (category != null)
                throw new Exception($"there is a category with name = {name}");
        }

        public void EnsureCategoryExist(string name)
        {
            var category = _CategoryQueryRepository.GetCategory(name);
            if (category == null)
                throw new Exception($"there is no category with name = {name}");
        }

        public void EnsureCategoryExist(int id)
        {
            var category = _CategoryQueryRepository.GetCategory(id);
            if (category == null)
                throw new Exception($"there is no category with id = {id}");
        }

        public async Task<List<CategoryDto>> GetCategories()
            => await _CategoryQueryRepository.GetAllCategories();

        public CategoryDto GetCategory(int id)
        {
            var category = _CategoryQueryRepository.GetCategory(id);
            if (category == null)
                throw new Exception($"there is no category with id = {id}");
            return category;
        }

        public CategoryDto GetCategory(string name)
        {
            var category = _CategoryQueryRepository.GetCategory(name);
            if (category == null)
                throw new Exception($"there is no category with name = {name}");
            return category;
        }

        public async Task SetCategory(string name, int displayOrder, int parentCategoryId)
        {
            await _CategoryCommandRepository.AddCategory(name, displayOrder, parentCategoryId, DateTime.Now, false);
        }

        public void UpdateCategory(int id, string name, int displayOrder, int parentCategoryId)
        {
            _CategoryCommandRepository.UpdateCategory(id, name, parentCategoryId, displayOrder);
        }
    }
}
