using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        List<Brand> GetAllBrands();
    }
}
