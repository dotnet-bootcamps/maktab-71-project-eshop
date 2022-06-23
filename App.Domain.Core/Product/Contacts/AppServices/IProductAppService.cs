
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetProducts();
        Task SetProduct(CreateProductDto command);
        ProductDto GetProduct(int id);
        ProductDto GetProduct(string name);
        void UpdateProduct(UpdateProductDto command);
        void DeleteProduct(int id);
    }
}
