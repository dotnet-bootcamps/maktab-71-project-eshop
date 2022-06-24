

using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task Set(ProductDto model);
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
        Task Update(ProductDto model);
        Task Delete(int id);
        Task EnsureProductDoesNotExist(string name);
        Task EnsureProductExist(string name);
        Task EnsureProductExist(int id);

    }
}
