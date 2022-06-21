using App.Domain.Core.Product.Contacts.Repositories.Color;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ColorService : IColorService
    {
        private readonly IColorCommandRepository _commandRepository;
        private readonly IColorQueryRepository _queryRepository;
        public ColorService(IColorCommandRepository categoryCommandRepository, IColorQueryRepository categoryQueryRepository)
        {
            _queryRepository = categoryQueryRepository;
            _commandRepository = categoryCommandRepository;
        }

        public async Task Delete(int id)
        {
            await _commandRepository.Delete(id);
        }

        public async Task EnsureDoesNotExist(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record != null)
            {
                throw new Exception($"Category {name} Already Exists!");
            }
        }

        public async Task EnsureExists(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
        }

        public async Task EnsureExists(int id)
        {
            var record = await _queryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
        }

        public async Task<ColorDto> Get(int id)
        {
            return await _queryRepository.Get(id);
        }

        public async Task<ColorDto> Get(string name)
        {
            return await _queryRepository.Get(name);
        }

        public async Task<List<ColorDto>> GetAll()
        {
            return await _queryRepository.GetAll();
        }

        public async Task Set(ColorDto dto)
        {
            await _commandRepository.Add(dto);
        }

        public async Task Update(ColorDto dto)
        {
            await _commandRepository.Update(dto);
        }
    }
}
