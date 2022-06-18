using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        List<BrandDto> GetAllBrands(int operatorId);
        public void CreateBrand(Brand brand);
    }
}
