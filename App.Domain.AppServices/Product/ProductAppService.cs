using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Permission.Enums;
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
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService)
        {
            _productService= productService;
        }
        public async Task Delete(int id)
        {
            await _productService.EnsureProductExist(id);
           await _productService.Delete(id);
        }

        public async Task<ProductDto> Get(int id)
        {
            return await _productService.Get(id);
        }

        public async Task<ProductDto> Get(string name)
        {
            return await _productService.Get(name);
        }

        public Task<List<ProductDto>> GetAll()
        {
           return _productService.GetAll();
        }

        public async Task Set(ProductDto model)
        {
            await _productService.EnsureProductDoesNotExist(model.Name);
            await _productService.Set(model);
        }

        public async Task Update(ProductDto model)
        {
            await _productService.EnsureProductExist(model.Id);
            await _productService.Update(model);
        }
    }
}
