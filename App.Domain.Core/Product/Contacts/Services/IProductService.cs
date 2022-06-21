

using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductOutputDto>> GetAll();
        Task<ProductOutputDto> Get(int id);
        Task<ProductOutputDto> Get(string name);
        Task Add(ProductInputDto product);
        Task Update(int id, ProductInputDto product, DateTime creationDate, bool isDeleted);
        Task Remove(int id);
        Task EnsureProductDoseNotExist(int modelId, int categoryId, int brandId);
        Task EnsureProductExists(int id);
        Task EnsureProductExists(string name);
    }
}
