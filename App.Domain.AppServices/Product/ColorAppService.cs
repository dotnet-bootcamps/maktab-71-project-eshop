using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ColorAppService : IColorAppService
    {
        private readonly IColorService _service;
        public ColorAppService(IColorService categoryService)
        {
            _service = categoryService;
        }
        public async Task Delete(int id)
        {
            await _service.EnsureExists(id);
            await _service.Delete(id);
        }

        public async Task<ColorDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<ColorDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<ColorDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task Set(ColorDto dto)
        {
            await _service.EnsureDoesNotExist(dto.Name);
            await _service.Set(dto);
        }

        public async Task Update(ColorDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Update(dto);
        }
    }
}
