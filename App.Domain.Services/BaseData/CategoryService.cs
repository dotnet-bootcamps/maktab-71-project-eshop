using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public CategoryService(ICategoryCommandRepository categoryCommandRepository
            ,ICategoryQueryRepository categoryQueryRepository
            )
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        //Commands :
        public async Task<int> Create(string name, int displayOrder, int parentCategoryId)
        {
            var id = await _categoryCommandRepository.Add(name, displayOrder, DateTime.Now, parentCategoryId, false, true);
            return id;
        }

        public async Task Delete(int id)
        {
            await _categoryCommandRepository.Remove(id);
        }
        public async Task Update(int id, string name, int displayOrder, int parentCategoryId, bool isActive, bool isDeleted)
        {
            await _categoryCommandRepository.Update(id, name, displayOrder, parentCategoryId, isActive, isDeleted);
        }

        //Queries :
        public async Task<CategoryDto?> Get(int id)
        {
            var category = await _categoryQueryRepository.Get(id);
            return category;
        }

        public async Task<CategoryDto?> Get(string name)
        {
            var category = await _categoryQueryRepository.Get(name);
            return category;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _categoryQueryRepository.GetAll();
            return categories;
        }

        //Ensurness :
        public async Task EnsureCategoryIsExist(string name)
        {
            var category = await _categoryQueryRepository.Get(name);
            if (category == null)
                throw new Exception($"There is no Category with Name :{name}");
        }

        public async Task EnsureCategoryIsExist(int id)
        {
            var category = await _categoryQueryRepository.Get(id);
            if (category == null)
                throw new Exception($"There is no Category with Id :{id}");
        }

        public async Task EnsureCategoryIsNotExist(string name)
        {
            var category = await _categoryQueryRepository.Get(name);
            if (category != null)
                throw new Exception($"There is A Category with Name :{name}");
        }
    }
}
