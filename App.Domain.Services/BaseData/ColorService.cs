using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Services.BaseData
{
    public class ColorService:IColorService
    {
        private readonly IColorCommandRepository _colorCommandRepository;
        private readonly IColorQueryRepository _colorQueryRepository;

        public ColorService(IColorCommandRepository colorCommandRepository, IColorQueryRepository colorQueryRepository)
        {
            _colorCommandRepository = colorCommandRepository;
            _colorQueryRepository = colorQueryRepository;
        }

        public async Task<List<ColorDto>> GetColors()
        {
            return await _colorQueryRepository.GetAllColor();
        }

        public async Task SetColor(string name, string colorCode)
        {
            await _colorCommandRepository.AddColor(name, colorCode,DateTime.Now, false);
        }

        public ColorDto GetColor(int id)
        {
            var color = _colorQueryRepository.GetColorBy(id);
            if (color == null)
                throw new Exception($"there is no color with id = {color}");
            return color;
        }

        public ColorDto GetColor(string name)
        {
            var color = _colorQueryRepository.GetColorBy(name);
            if (color == null)
            {
                throw new Exception($"there is no color with name ={color}");
            }
            return color;
        }

        public void UpdateColor(int id, string name, string colorCode)
        {
            _colorCommandRepository.UpdateColor(id,name,colorCode);
        }

        public void DeleteColor(int id)
        {
            _colorCommandRepository.DeleteColor(id);
        }

        public void EnsureColorDoseNotExist(string name)
        {
            var color = _colorQueryRepository.GetColorBy(name);
            if (color != null)
            {
                throw new Exception($"there is a color with name = {name}");
            }
        }

        public void EnsureColorExist(string name)
        {
            var color = _colorQueryRepository.GetColorBy(name);
            if (color == null)
            {
                throw new Exception($"there is no color with name = {name}");
            }

        }

        public void EnsureColorExist(int id)
        {
            var color = _colorQueryRepository.GetColorBy(id);
            if (color == null)
            {
                throw new Exception($"there is no color with name = {id}");
            }
        }
    }
}
