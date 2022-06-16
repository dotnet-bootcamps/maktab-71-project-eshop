
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
       
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductService(IProductRepository productRepository
            , IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }
        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        
    }
}
