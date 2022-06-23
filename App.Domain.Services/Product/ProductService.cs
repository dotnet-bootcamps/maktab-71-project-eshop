
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
        private readonly IProductCommandRepository _ProductCommandRepository;
        private readonly IProductQueryRepository _ProductQueryRepository;

        public ProductService(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository)
        {
            _ProductCommandRepository = productCommandRepository;
            _ProductQueryRepository = productQueryRepository;
        }

        public void DeleteProduct(int id)
        {
            _ProductCommandRepository.DeleteProduct(id);
        }

        public void EnsureProductDoseNotExist(string name)
        {
            var product = _ProductQueryRepository.GetProduct(name);
            if (product != null)
                throw new Exception($"there is a product with name = {name}");
        }

        public void EnsureProductExist(string name)
        {
            var product = _ProductQueryRepository.GetProduct(name);
            if (product == null)
                throw new Exception($"there is a product with name = {name}");
        }

        public void EnsureProductExist(int id)
        {
            var product = _ProductQueryRepository.GetProduct(id);
            if (product == null)
                throw new Exception($"there is a product with id = {id}");
        }

        public ProductDto GetProduct(int id)
        {
            var product = _ProductQueryRepository.GetProduct(id);
            if (product == null)
                throw new Exception($"there is no product with id = {id}");
            return product;
        }

        public ProductDto GetProduct(string name)
        {
            var product = _ProductQueryRepository.GetProduct(name);
            if (product == null)
                throw new Exception($"there is no product with name = {name}");
            return product;
        }

        public async Task<List<ProductDto>> GetProducts()
            => await _ProductQueryRepository.GetAllProduct();

        public async Task SetProduct(CreateProductDto command)
        {
            await _ProductCommandRepository.AddProduct(command);
        }

        public void UpdateProduct(UpdateProductDto command)
        {
            _ProductCommandRepository.UpdateProduct(command);
        }
    }
}
