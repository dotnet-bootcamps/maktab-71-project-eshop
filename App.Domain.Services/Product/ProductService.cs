
using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository;

        public ProductService(IProductQueryRepository productQueryRepository
            , IProductCommandRepository productCommandRepository)
        {
            _productQueryRepository = productQueryRepository;
            _productCommandRepository = productCommandRepository;
        }
        public async Task Delete(int id)
        {
             await _productCommandRepository.DeleteProduct(id);
        }

        public async Task EnsureProductDoesNotExist(string name)
        {
            var product = await _productQueryRepository.Get(name);
            if (product != null)
                throw new Exception($"there is a product with name = {name}");
        }

        public async Task EnsureProductExist(string name)
        {
            var product = await _productQueryRepository.Get(name);
            if (product != null)
                throw new Exception($"there is no product with name = {name}");
        }

        public async Task EnsureProductExist(int id)
        {
            var product = await _productQueryRepository.Get(id);
            if (product != null)
                throw new Exception($"there is no product with name = {id}");
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await _productQueryRepository.Get(id);
            if (product == null)
                throw new Exception($"there is no product with id = {id}");
            return product;
        }

        public async Task<ProductDto> Get(string name)
        {
            var product = await _productQueryRepository.Get(name);
            if (product == null)
                throw new Exception($"there is no product with id = {name}");
            return product;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return await _productQueryRepository.GetAll();
        }

        public async Task Set(ProductDto model)
        {
            await _productCommandRepository.AddProduct(model);
        }

        public async Task Update(ProductDto model)
        {
            await _productCommandRepository.UpdateProduct(model);
        }
    }
}
