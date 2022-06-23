using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class TagAppService : ITagAppService
    {
        private readonly ITagService _tagService;
        private readonly IPermissionService _permissionService;

        public TagAppService(ITagService tagService
            ,IPermissionService permissionService)
        {
            _tagService = tagService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(string name, int tagCategoryId, bool hasValue)
        {
            await _tagService.EnsureTagIsNotExist(name);
            var id = await _tagService.Create(name, tagCategoryId, hasValue);
            return id;
        }

        public async Task Delete(int id)
        {
            await _tagService.EnsureTagIsExist(id);
            await _tagService.Delete(id);
        }

        public async Task Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted)
        {
            await _tagService.EnsureTagIsExist(id);
            await _tagService.Update(id, name, tagCategoryId, hasValue, isDeleted);
        }

        public async Task<TagDto> Get(int id)
        {
            await _tagService.EnsureTagIsExist(id);
            var tag = await _tagService.Get(id);
            return tag;
        }

        public async Task<TagDto> Get(string name)
        {
            await _tagService.EnsureTagIsExist(name);
            var tag = await _tagService.Get(name);
            return tag;
        }

        public async Task<List<TagDto>> GetAll()
        {
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewTags);
            var tags = await _tagService.GetAll();
            return tags;
        }

        
    }
}
