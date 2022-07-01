
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _service;
        public ProductAppService(IProductService categoryService)
        {
            _service = categoryService;
        }
        public async Task Delete(int id)
        {
            await _service.EnsureExists(id);
            await _service.Delete(id);
        }

        public async Task<ProductDto> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<ProductDto> Get(string name)
        {
            return await _service.Get(name);
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyword, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            return await _service.GetProducts(categoryId, keyword, minPrice, maxPrice, brandId, cancellationToken);
        }

        public async Task Set(ProductDto dto)
        {
            await _service.EnsureDoesNotExist(dto.Name);
            await _service.Set(dto);
        }

        public async Task Update(ProductDto dto)
        {
            await _service.EnsureExists(dto.Id);
            await _service.Update(dto);
        }

    }
}
