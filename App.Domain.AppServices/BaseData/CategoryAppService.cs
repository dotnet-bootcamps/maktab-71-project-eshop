using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IPermissionService _permissionService;

        public CategoryAppService(ICategoryService categoryService
            , IPermissionService permissionService)
        {
            _categoryService = categoryService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(string name, int displayOrder, int parentCategoryId)
        {
            await _categoryService.EnsureCategoryIsExist(name);
            var id = await _categoryService.Create(name, displayOrder, parentCategoryId);
            return id;
        }

        public async Task Delete(int id)
        {
            await _categoryService.EnsureCategoryIsExist(id);
            await _categoryService.Delete(id);

        }
        public async Task Update(int id, string name, int displayOrder, int parentCategoryId, bool isActive, bool isDeleted)
        {
            await _categoryService.EnsureCategoryIsExist(id);
            await _categoryService.Update(id, name, displayOrder, parentCategoryId, isActive, isDeleted);

        }
        public async Task<CategoryDto> Get(int id)
        {
            await _categoryService.EnsureCategoryIsExist(id);
            var category = await _categoryService.Get(id);
            return category;
        }

        public async Task<CategoryDto> Get(string name)
        {
            await _categoryService.EnsureCategoryIsExist(name);
            var category = await _categoryService.Get(name);
            return category;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return categories;
        }


    }
}
