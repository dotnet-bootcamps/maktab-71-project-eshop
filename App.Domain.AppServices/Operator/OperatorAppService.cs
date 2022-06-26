using App.Domain.Core.Operator.Contract.AppServices;
using App.Domain.Core.Operator.Contract.Services;
using App.Domain.Core.Operator.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Operator
{
    public class OperatorAppService : IOperatorAppService
    {
        private readonly IOperatorService _service;
        public OperatorAppService(IOperatorService operatorService)
        {
            _service = operatorService;
        }
        public async Task Delete(int id)
        {
            await _service.EnsureExists(id);
            await _service.Delete(id);
        }

        public async Task<OperatorDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<OperatorDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<OperatorDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task Set(OperatorDto dto)
        {
            await _service.EnsureDoesNotExist(dto.Name);
            await _service.Set(dto);
        }

        public async Task Update(OperatorDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Update(dto);
        }
    }
}
