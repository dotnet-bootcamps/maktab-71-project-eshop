using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductService(IProductCommandRepository productCommandRepository
            ,IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
        }
        public async Task<int> Create(ProductInputDto product,int operatorId)
        {
            var productt =new ProductDto()
            {
                Name = product.Name,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelId = product.ModelId,
                Description = product.Description,
                CreationDate = DateTime.Now,
                IsDeleted = false,
                Count = product.Count,
                IsActive = true,
                IsOrginal = product.IsOrginal,
                IsShowPrice = true,
                OperatorId = operatorId,
                Price = product.Price,
                Weight = product.Weight
            };
            var id=await _productCommandRepository.Add(productt);
            return id;
        }

        public async Task Delete(int id)
        {
            await _productCommandRepository.Remove(id);
        }
        public async Task Update(ProductUpdateDto product)
        {
            var productt = new ProductDto()
            {
                Name = product.Name,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelId = product.ModelId,
                Description = product.Description,                
                IsDeleted = product.IsDeleted,
                Count = product.Count,
                IsActive = product.IsActive,
                IsOrginal = product.IsOrginal,
                IsShowPrice = product.IsShowPrice,                
                Price = product.Price,
                Weight = product.Weight
            };
            await _productCommandRepository.Update(productt);
        }
        

        public async Task<ProductDto?> Get(int id)
        {
            var product = await _productQueryRepository.Get(id);
            return product;
        }

        public async Task<ProductDto?> Get(string name, int brandId, int categoryId, int modelId)
        {
            var product = await _productQueryRepository.Get(name, brandId, categoryId, modelId);
            return product;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productQueryRepository.GetAll();
            return products;
        }

        public async Task EnsureProductIsExist(string name, int brandId, int categoryId, int modelId)
        {
            var product = await _productQueryRepository.Get(name, brandId, categoryId, modelId);
            if (product == null)
                throw new Exception($"There Is No Product!");
        }

        public async Task EnsureProductIsExist(int id)
        {
            var product = await _productQueryRepository.Get(id);
            if (product == null)
                throw new Exception($"There Is No Product!");
        }

        public async Task EnsureProductIsNotExist(string name, int brandId, int categoryId, int modelId)
        {
            var product = await _productQueryRepository.Get(name, brandId, categoryId, modelId);
            if (product != null)
                throw new Exception($"There Is A Product!");
        }


    }
}
