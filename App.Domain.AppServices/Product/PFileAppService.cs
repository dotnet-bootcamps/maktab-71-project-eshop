using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class PFileAppService : IPFileAppService
    {
        private readonly IPFileService _service;
        public PFileAppService(IPFileService pFileService)
        {
            _service = pFileService;

        }
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        public async Task<PFileDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<PFileDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<PFileDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task Set(PFileDto dto)
        {

            await _service.Set(dto);
        }

        public async Task Update(PFileDto dto)
        {
            await _service.Update(dto);
        }
    }
}
