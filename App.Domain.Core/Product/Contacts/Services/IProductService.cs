

using App.Domain.Core.Product.Dtos;
using productentity=App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProduct();
        void DeleteProduct(int id);
        void SetProduct(ProductDto Pitem);

    }
}
