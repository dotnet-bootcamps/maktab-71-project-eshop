using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
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

        public void CreateBrand(Brand brand)
        {
            _brandRepository.Create(brand);
        }

        public List<BrandDto> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }
    }
}
