using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ModelAppService : IModelAppService
    {
        private readonly IModelService _service;
        public ModelAppService(IModelService categoryService)
        {
            _service = categoryService;
        }
        public async Task Delete(int id)
        {
            await _service.EnsureExists(id);
            await _service.Delete(id);
        }

        public async Task<ModelDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<ModelDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<ModelDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task Set(ModelDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Set(dto);
        }

        public async Task Update(ModelDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Update(dto);
        }
    }
}
