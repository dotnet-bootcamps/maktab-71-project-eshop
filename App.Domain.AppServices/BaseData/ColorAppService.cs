using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ColorAppService : IColorAppService
    {
        private readonly IColorService _colorService;
        private readonly IPermissionService _permissionService;

        public ColorAppService(IColorService colorService
            ,IPermissionService permissionService)
        {
            _colorService = colorService;
            _permissionService = permissionService;
        }

        public async Task<int> Create(string name, string code)
        {
            await _colorService.EnsureColorIsNotExist(name);
            var id = await _colorService.Create(name, code);
            return id;
        }

        public async Task Delete(int id)
        {
            await _colorService.EnsureColorIsExist(id);
            await _colorService.Delete(id);
        }
        public async Task Update(int id, string name, string code, bool isDeleted)
        {
            await _colorService.EnsureColorIsExist(id);
            await _colorService.Update(id, name, code, isDeleted);
        }

        public async Task<ColorDto> Get(int id)
        {
            await _colorService.EnsureColorIsExist(id);
            var color = await _colorService.Get(id);
            return color;
        }

        public async Task<ColorDto> Get(string name)
        {
            await _colorService.EnsureColorIsExist(name);
            var color = await _colorService.Get(name);
            return color;
        }

        public async Task<List<ColorDto>> GetAll()
        {
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewColors);
            var colors= await _colorService.GetAll();
            return colors;
        }

        
    }
}
