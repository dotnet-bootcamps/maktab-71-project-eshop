using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
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
        public ColorAppService(IColorService colorService)
        {
            _colorService = colorService;
        }
        public async Task Delete(int id)
        {
            await _colorService.EnsureFileTypeExist(id);
            await _colorService.Delete(id);
        }

        public async Task<ColorDto> Get(int id)
        {
           return await _colorService.Get(id);
        }

        public async Task<ColorDto> Get(string code)
        {
            return await _colorService.Get(code);
        }

        public async Task<List<ColorDto>> GetAll()
        {
          return await _colorService.GetAll();
        }

        public async Task Set(string name, string code)
        {
            await _colorService.EnsureFileTypeDoseNotExist(code);
            await _colorService.Set(name, code);
        }

        public async Task Update(int id, string name, string code, bool isDeleted)
        {
            await _colorService.EnsureFileTypeExist(id);
           await _colorService.Update(id, name, code, isDeleted);
        }
    }
}
