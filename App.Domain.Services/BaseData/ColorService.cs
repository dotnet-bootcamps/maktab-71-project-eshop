using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public int CreateColor(Color color)
        {
            _colorRepository.Create(color);
            return color.Id;
        }

        public Color GetColorById(int id)
        {
            var record=_colorRepository.GetById(id);
            return record;
        }

        public List<ColorDto> GetAllColors()
        {
            var record = _colorRepository.GetAll()
                .Select(x => new ColorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CreationDate = x.CreationDate,
                    IsDeleted = x.IsDeleted
                })
                .ToList();
            return record;
        }

        public bool RemoveColor(int id)
        {
            return _colorRepository.Remove(id);
        }

        public void UpdateColor(Color color)
        {
            _colorRepository.Update(color);
        }

        public void EnsureColorIsNotExist(string name, string code)
        {
            var color = _colorRepository.GetExitingColor(name, code);
            if (color is not null)
                throw new Exception("Color Already Exist");
        }
    }
}
