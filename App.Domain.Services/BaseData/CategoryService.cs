using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
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
        public async Task<int> Create(string name, int displayOrder, int parentCategoryId)
        {
            var id = await _categoryCommandRepository.Add(name, displayOrder,parentCategoryId)
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EnsureCategoryIsExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task EnsureCategoryIsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task EnsureCategoryIsNotExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, string name, int displayOrder, int parentCategoryId, int isActive, int isDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
