using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ColorService : IColorService
    {
        private readonly IColorQueryRepository _colorQueryRepository;
        private readonly IColorCommandRepository _colorCommandRepository;

        public ColorService(IColorQueryRepository colorQueryRepository,IColorCommandRepository colorCommandRepository)
        {
            _colorQueryRepository = colorQueryRepository;
            _colorCommandRepository = colorCommandRepository;
        }
        public async Task<List<ColorDTO>> GetAll()
        {
            return await _colorQueryRepository.GetAll();
        }
        public async Task<ColorDTO> Get(int id)
        {
            var result=await _colorQueryRepository.Get(id);
            if (result == null)
            {
                throw new Exception($"There is no Color with id {id} In Database");
            }
            return result;
        }

        public async Task<ColorDTO> Get(string name)
        {
            var result=await _colorQueryRepository.Get(name);
            if (result == null)
            {
                throw new Exception($"There is no Color with name {name} In Database");
            }
            return result;
        }

        public async Task SetColor(string code, string name)
        {
            await _colorCommandRepository.AddColor(code, name, DateTime.Now, false);
        }

        public async Task DeleteColor(int id)
        {
            await _colorCommandRepository.DeleteColor(id);
        }

        public async Task UpdateColor(int id,string code,string name)
        {
            await _colorCommandRepository.UpdateColor(id, code, name);
        }

        public async Task EnsureColorDoseNotExist(string name)
        {
            var color =await _colorQueryRepository.Get(name);
            if (color != null)
            {
                throw new Exception($"Color {name} Exist in Color Table");
            }   
        }

        public async Task EnsureColorExist(string name)
        {
            var color =await _colorQueryRepository.Get(name);
            if (color == null)
            {
                throw new Exception($"Color {name} Not Exist in Color Table");
            }
        }

        public async Task EnsureColorExist(int id)
        {
            var color =await _colorQueryRepository.Get(id);
            //var color = GetFirstOrDefault(x => x.Id == id);
            if (color == null)
            {
                throw new Exception($"Color ID {id} Not Exist in Color Table");
            }
        }

        public ColorDTO? GetFirstOrDefault(Expression<Func<ColorDTO, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            return _colorQueryRepository.GetFirstOrDefault(filter, includeProperties, tracked);
        }
    }
}
