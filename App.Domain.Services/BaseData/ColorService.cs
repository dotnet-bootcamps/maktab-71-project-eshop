using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{

    public class ColorService : IColorService
    {
        private readonly IColorCommandRepository _colorCommandRepository;
        private readonly IColorQueryRepository _bcolorQueryRepository;

        public ColorService(IColorCommandRepository colorCommandRepository, 
            IColorQueryRepository bcolorQueryRepository)
        {
            _colorCommandRepository = colorCommandRepository;
            _bcolorQueryRepository = bcolorQueryRepository;
        }

        public void DeleteColor(int id)
        {
            _colorCommandRepository.DeleteColor(id);
        }

        public void EnsureColorDoseNotExist(string name)
        {
            var color = _bcolorQueryRepository.GetColor(name);
            if (color != null)
                throw new Exception($"there is a color with name = {name}");
        }

        public void EnsureColorExist(string name)
        {
            var color = _bcolorQueryRepository.GetColor(name);
            if (color == null)
                throw new Exception($"there is no color with name = {name}");
        }

        public void EnsureColorExist(int id)
        {
            var color = _bcolorQueryRepository.GetColor(id);
            if (color == null)
                throw new Exception($"there is no Color with id = {id}");
        }

        public ColorDto GetColor(int id)
        {
            var color = _bcolorQueryRepository.GetColor(id);
            if (color == null)
                throw new Exception($"there is no color with id = {id}");
            return color;
        }

        public ColorDto GetColor(string name)
        {
            var color = _bcolorQueryRepository.GetColor(name);
            if (color == null)
                throw new Exception($"there is no color with name = {name}");
            return color;
        }

        public async Task<List<ColorDto>> GetColors() 
            => await _bcolorQueryRepository.GetAllColors();

        public async Task SetColor(string name, string code)
        {
            await _colorCommandRepository.AddColor(name,code, DateTime.Now, false);
        }

        public void UpdateColor(int id, string name, string code)
        {
            _colorCommandRepository.UpdateColor(id, name,code);
        }
    }
}
