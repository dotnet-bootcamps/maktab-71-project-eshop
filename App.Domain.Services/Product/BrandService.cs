using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Domain.Core.ProductAgg.Contracts.Services;
using App.Domain.Core.ProductAgg.DTOs;
using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void Create(CreateBrand command)
        {
            Brand brand = new Brand(command.Name,command.DisplayOrder);
            _brandRepository.Create(brand);
        }

        public void Delete(int id)
        {
            _brandRepository.Remove(id);
        }

        public bool Exists(string name )
        {
            return _brandRepository.Exists(name);
        }
        public bool Exists(int id)
        {
            return _brandRepository.Exists(id);
        }

        public Brand GetBrandBy(int id) => _brandRepository.GetBy(id);

        public List<BrandViewModel> GetBrands()
        {
            var brands = _brandRepository.GetAll().Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                DisplayOrder=b.DisplayOrder,
                CreationDate=b.CreationDate
            });
            return brands.ToList();
        }

        public BrandViewModel GetBrandViewModelBy(int id)
        {
            var brand = _brandRepository.GetBy(id);
            return new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayOrder = brand.DisplayOrder,
                CreationDate = brand.CreationDate
            };
        } 
        
        

        public void Update(Brand brand)
        {
            _brandRepository.Update(brand);
        }
    }
}
