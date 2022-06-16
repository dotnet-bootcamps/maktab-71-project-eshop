using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        List<Brand> GetAllBrands(int operatorId);
    }
}
