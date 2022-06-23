using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task SetProduct(CreateProductDto command);
        ProductDto GetProduct(int id);
        ProductDto GetProduct(string name);
        void UpdateProduct(UpdateProductDto command);
        void DeleteProduct(int id);
        void EnsureProductDoseNotExist(string name);
        void EnsureProductExist(string name);
        void EnsureProductExist(int id);
    }
}
