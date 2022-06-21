using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Operator.Contract.Services;
using App.Domain.Core.Operator.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Operator
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorCommandRepository _commandRepository;
        private readonly IOperatorQueryRepository _queryRepository;
        public OperatorService(IOperatorCommandRepository categoryCommandRepository, IOperatorQueryRepository categoryQueryRepository)
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
                throw new Exception($"Operator {name} Already Exists!");
            }
        }

        public async Task EnsureExists(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"No Operator with name : {name}!");
            }
        }

        public async Task EnsureExists(int id)
        {
            var record = await _queryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"No Operator with id : {id}!");
            }
        }

        public async Task<OperatorDto> Get(int id)
        {
            return await _queryRepository.Get(id);
        }

        public async Task<OperatorDto> Get(string name)
        {
            return await _queryRepository.Get(name);
        }

        public async Task<List<OperatorDto>> GetAll()
        {
            return await _queryRepository.GetAll();
        }

        public async Task Set(OperatorDto dto)
        {
            await _commandRepository.Add(dto);
        }

        public async Task Update(OperatorDto dto)
        {
            await _commandRepository.Update(dto);
        }
    }
}
