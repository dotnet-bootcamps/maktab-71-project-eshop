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
    public class ColorAppService: IColorAppService
    {
        private readonly IColorService _colorService;

        public ColorAppService(IColorService colorService)
        {
            _colorService = colorService;
        }

        public void DeleteColor(int id)
        {
            _colorService.EnsureColorExist(id);
            _colorService.DeleteColor(id);
        }

        public ColorDto GetColor(int id)
            => _colorService.GetColor(id);

        public ColorDto GetColor(string name)
            => _colorService.GetColor(name);

        public async Task<List<ColorDto>> GetColors()
            => await _colorService.GetColors();

        public async Task SetColor(string name,string code)
        {
            _colorService.EnsureColorDoseNotExist(name);
            await _colorService.SetColor(name,code);
        }

        public void UpdateColor(int id, string name,string code)
        {
            _colorService.EnsureColorExist(id);
            _colorService.UpdateColor(id, name,code);
        }
    }
}
