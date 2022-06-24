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
        private readonly IColorQueryRepository _colorQueryRepository;
        private readonly IColorCommandRepository _colorCommandRepository;

        public ColorService(IColorQueryRepository colorQueryRepository
            ,IColorCommandRepository colorCommandRepository)
        {
            _colorQueryRepository = colorQueryRepository;
            _colorCommandRepository = colorCommandRepository;
        }
        public async Task Delete(int id)
        {
            await _colorCommandRepository.DeleteColor(id);
        }

        public async Task EnsureFileTypeDoseNotExist(string code)
        {
          var color = await _colorQueryRepository.Get(code);
            if(color != null)
            {
                throw new Exception($"There is a color with code {code}");
            }
        }

        public async Task EnsureFileTypeExist(string code)
        {
            var color = await _colorQueryRepository.Get(code);
            if (color != null)
            {
                throw new Exception($"There is no color with code {code}");
            }
        }

        public async Task EnsureFileTypeExist(int id)
        {
            var color = await _colorQueryRepository.Get(id);
            if (color != null)
            {
                throw new Exception($"There is no color with code {id}");
            }
        }

        public async Task<ColorDto> Get(int id)
        {
            return await _colorQueryRepository.Get(id);
        }

        public async Task<ColorDto> Get(string code)
        {
            return await _colorQueryRepository.Get(code);
        }

        public async Task<List<ColorDto>> GetAll()
        {
           return await _colorQueryRepository.GetAll();
        }

        public async Task Set(string name, string code)
        {
           await _colorCommandRepository.AddColor(name , DateTime.Now , code , false);
        }

        public async Task Update(int id, string name, string code, bool isDeleted)
        {
            await _colorCommandRepository.UpdateColor(id , name , code , isDeleted);
        }
    }
}
