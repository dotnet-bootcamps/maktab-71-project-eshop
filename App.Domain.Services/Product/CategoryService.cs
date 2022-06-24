using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Services.Product
{
    public class CategoryService:ICateGoryService
    {
        private readonly ICategoryCommandRepository _commandRepository;
        private readonly ICategoryQueryRepository _queryRepository;

        public CategoryService(ICategoryCommandRepository commandRepository, ICategoryQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }


        public async Task<List<CategoryDto>> GetCategorys()
        {
           return await _queryRepository.GetAllCategory();
        }

        public async Task SetCategory(bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
            bool isDeleted)
        {
            await _commandRepository.AddCategory(isActive, displayOrder, parentCagetoryId, name, DateTime.Now, false);
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _queryRepository.GetCategoryBy(id);
            if (category == null)
                throw new Exception($"there is no category with id = {category}");
            return category;
        }

        public CategoryDto GetCategory(string name)
        {
            var category = _queryRepository.GetCategoryBy(name);
            if (category == null)
                throw new Exception($"there is no category with id = {category}");
            return category;
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

        public void EnsureCategoryDoseNotExist(string name)
        {
            throw new NotImplementedException();
        }

        public void EnsureCategoryExist(string name)
        {
            throw new NotImplementedException();
        }

        public void EnsureCategoryExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
