using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IBrandRepository _brandRepository;
        public ProductService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public List<Brand> GetAllBrands()
        {
            var brands = _brandRepository.GetAll();
            return brands;
        }
    }
}
