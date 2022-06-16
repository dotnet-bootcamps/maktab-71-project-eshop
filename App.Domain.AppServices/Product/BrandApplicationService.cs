using App.Domain.Core.ProductAgg.Contracts.ApplicationServices;
using App.Domain.Core.ProductAgg.Contracts.Services;
using App.Domain.Core.ProductAgg.DTOs;
using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class BrandApplicationService : IBrandApplicationService
    {
        private readonly IBrandService _brandService;

        public BrandApplicationService(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public void Create(CreateBrand brand)
        {
            if (_brandService.Exists(brand.Name))
                throw new Exception("Brand already exists");
            else
                _brandService.Create(brand);
        }
        public void Delete(int id)
        {
            if (_brandService.Exists(id))
                throw new Exception("Brand does not exist");
            else
                _brandService.Delete(id);
        }

        public Brand GetBrandBy(int id) => _brandService.GetBrandBy(id);

        public List<BrandViewModel> GetBrands() => _brandService.GetBrands();

        public BrandViewModel GetBrandViewModelBy(int id) => _brandService.GetBrandViewModelBy(id);

        public void Update(Brand command)
        {
            var brand = _brandService.GetBrandBy(command.Id);
            if (brand == null)
                throw new Exception("Brand does not exist");
            else
            {
                brand.Name = command.Name;
                brand.DisplayOrder = command.DisplayOrder;
                _brandService.Update(brand);
            }
        }
    }
}
