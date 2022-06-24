using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository;

        public ProductService(IProductCommandRepository productCommandRepository,
            IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _productQueryRepository.GetAllProduct();
        }

        public async Task SetProduct(int categoryId, int brandId, decimal Weight, bool IsOrginal, string description,
            int count, int modelId,
            long price, int operatorId, bool isShowPrice, string name)
        {
            await _productCommandRepository.AddProduct(categoryId, brandId, Weight, IsOrginal, description, count,
                modelId,
                price, isShowPrice, IsOrginal, operatorId, name, DateTime.Now, false);
        }

        public ProductDto GetProduct(int id)
        {
            var product = _productQueryRepository.GetProductBy(id);
            if (product == null)
                throw new Exception($"there is no product with id = {product}");
            return product;
        }

        public ProductDto GetProduct(string name)
        {
            var product = _productQueryRepository.GetProductBy(name);
            if (product == null)
                throw new Exception($"there is no product with id = {product}");
            return product;
        }

        public void UpdateProduct(int id, int categoryId, int brandId, decimal Weight, bool IsOrginal,
            string description, int count,
            int modelId, long price, int operatorId, bool isShowPrice, string name)
        {
            _productCommandRepository.UpdateProduct(id, categoryId, brandId, Weight, IsOrginal, description, count,
                modelId,
                price, isShowPrice, IsOrginal, operatorId, name, DateTime.Now, false);
        }

        public void DeleteProduct(int id)
        {
            _productCommandRepository.DeleteProduct(id);
        }

        public void EnsureProductDoseNotExist(string name)
        {
            var product = _productQueryRepository.GetProductBy(name);
            if (product != null)
            {
                throw new Exception($"there is a product with name = {name}");
            }
        }

        public void EnsureProductExist(string name)
        {
            var product = _productQueryRepository.GetProductBy(name);
            if (product == null)
            {
                throw new Exception($"there is no product with name = {name}");
            }
        }

        public void EnsureProductExist(int id)
        {
            var product = _productQueryRepository.GetProductBy(id);
            if (product == null)
            {
                throw new Exception($"there is no product with name = {id}");
            }
        }
    }
}