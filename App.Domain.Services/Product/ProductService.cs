
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

        public ProductService(
            IProductQueryRepository productQueryRepository,
            IProductCommandRepository productCommandRepository)
        {
            _productQueryRepository = productQueryRepository;
            _productCommandRepository = productCommandRepository;
        }
        public async Task<List<ProductOutputDto>> GetAll()
        {
            return await _productQueryRepository.GetAll();
        }

        public async Task<ProductOutputDto?> Get(int id)
        {
            return await _productQueryRepository.Get(id);
        }

        public async Task<ProductOutputDto?> Get(string name)
        {
            return await _productQueryRepository.Get(name);
        }

        public async Task Add(ProductInputDto product)
        {
            await _productCommandRepository.Add(product, DateTime.Now, false);
        }

        public async Task EnsureProductDoseNotExist(int modelId, int categoryId, int brandId)
        {
            ProductOutputDto? Product = await _productQueryRepository.Get(modelId, categoryId, brandId);
            if (Product != null)
                throw new Exception($"there is a product with modelId = { modelId } , categoryId = { categoryId } , brandId = { brandId }");
        }

        public async Task EnsureProductExists(int id)
        {
            var Product = await _productQueryRepository.Get(id);
            if (Product == null)
                throw new Exception($"there is no product with id = { id }");
        }

        public async Task EnsureProductExists(string name)
        {
            var Product = await _productQueryRepository.Get(name);
            if (Product == null)
                throw new Exception($"there is no product with name = { name }");
        }


        public async Task Remove(int id)
        {
            await _productCommandRepository.Delete(id);
        }

        public async Task Update(int id, ProductInputDto product, DateTime creationDate, bool isDeleted)
        {
            await _productCommandRepository.Update(id, product, creationDate, isDeleted);
        }
    }
}
