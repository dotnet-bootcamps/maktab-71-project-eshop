using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contarcts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ColorAppService : IColorAppService
    {
        private readonly IColorService _colorService;
        private readonly IPermissionService _permissionService;

        public ColorAppService(IColorService colorService,IPermissionService permissionService)
        {
            _colorService = colorService;
            _permissionService = permissionService;
        }
        public async Task<List<ColorDTO>> GetAll()
        {
            return await _colorService.GetAll();
        }
        public async Task<ColorDTO> Get(int id)
        {
            var result = await _colorService.Get(id);
            return result;
        }

        public async Task<ColorDTO> Get(string name)
        {
            var result = await _colorService.Get(name);
            return result;
        }

        public async Task SetColor(string code, string name)
        {
            await _permissionService.HasPermission(1, 1);
            await _colorService.EnsureColorDoseNotExist(name);
            await _colorService.SetColor(code, name);
        }

        public async Task DeleteColor(int id)
        {
            await _permissionService.HasPermission(1, 1);
            await _colorService.EnsureColorExist(id);
            await _colorService.DeleteColor(id);
        }

        public async Task UpdateColor(int id, string code, string name)
        {
            await _permissionService.HasPermission(1, 1);
            await _colorService.EnsureColorExist(id);
            await _colorService.UpdateColor(id, code, name);
        }
        public ColorDTO? GetFirstOrDefault(Expression<Func<ColorDTO, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            return _colorService.GetFirstOrDefault(filter, includeProperties, tracked);
        }
    }
}
