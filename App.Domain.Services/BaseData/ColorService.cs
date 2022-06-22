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
        private readonly IColorQueryRepository _colorQueryRepository;
        private readonly IColorCommandRepository _colorCommandRepository;

        public ColorService(IColorQueryRepository colorQueryRepository
            ,IColorCommandRepository colorCommandRepository)
        {
            _colorQueryRepository = colorQueryRepository;
            _colorCommandRepository = colorCommandRepository;
        }

        //Commands :
        public async Task<int> Create(string name, string code)
        {
            var id = await _colorCommandRepository.Add(name,code,DateTime.Now,false);
            return id;
        }

        public async Task Delete(int id)
        {
            await _colorCommandRepository.Remove(id);
        }
        public async Task Update(int id, string name, string code, bool isDeleted)
        {
            await _colorCommandRepository.Update(id, name, code, isDeleted);
        }
        
        //Queries :
        public async Task<ColorDto?> Get(int id)
        {
            var color = await _colorQueryRepository.Get(id);
            return color;
        }

        public async Task<ColorDto?> Get(string name)
        {
            var color = await _colorQueryRepository.Get(name);
            return color;
        }

        public async Task<List<ColorDto>> GetAll()
        {
            var colors = await _colorQueryRepository.GetAll();
            return colors;
        }
         //Ensurness :
        public async Task EnsureColorIsExist(string name)
        {
            var color = await _colorQueryRepository.Get(name);
            if(color == null)
                throw new Exception($"There is no Color with Name :{name}");
        }

        public async Task EnsureColorIsExist(int id)
        {
            var color = await _colorQueryRepository.Get(id);
            if (color == null)
                throw new Exception($"There is no Color with Id :{id}");
        }

        public async Task EnsureColorIsNotExist(string name)
        {
            var color = await _colorQueryRepository.Get(name);
            if (color != null)
                throw new Exception($"There is a Color with Name :{name}");
        }
    }
}
