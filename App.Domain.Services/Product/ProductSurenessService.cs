using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductSurenessService : IProductSurenessService
    {
        private readonly IBrandRepository _brandRepository;
        public ProductSurenessService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public void EnsureBrandIsNotExists(int id)
        {
            var brand = _brandRepository.GetBy(id);
            if (brand.Id == id)
                throw new Exception($"Brand by id={id} already exists");
        }
        public void EnsureBrandIsNotExists(string name)
        {
            var brand = _brandRepository.GetBy(name);
            if (brand.Name.ToLower() == name.ToLower())
                throw new Exception($"Brand by name={name} already exists");
        }
    }
}
