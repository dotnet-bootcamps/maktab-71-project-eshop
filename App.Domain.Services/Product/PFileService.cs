using App.Domain.Core.Product.Contacts.Repositories.PFile;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class PFileService : IPFileService
    {
        private readonly IPFileCommandRepository _commandRepository;
        private readonly IPFileQueryRepository _queryRepository;
        public PFileService(IPFileCommandRepository pFileCommandRepository, IPFileQueryRepository pFileQueryRepository)
        {
            _queryRepository = pFileQueryRepository;
            _commandRepository = pFileCommandRepository;
        }

        public async Task Delete(int id)
        {
            await _commandRepository.Delete(id);
        }

        public async Task<PFileDto> Get(int id)
        {
            var record = await _queryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
            return record;
        }

        public async Task<PFileDto> Get(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
            return record;
        }

        public async Task<List<PFileDto>> GetAll()
        {
            return await _queryRepository.GetAll();
        }

        public async Task Set(PFileDto dto)
        {
            await _commandRepository.Add(dto);
        }

        public async Task Update(PFileDto dto)
        {
            await _commandRepository.Update(dto);
        }
    }
}
