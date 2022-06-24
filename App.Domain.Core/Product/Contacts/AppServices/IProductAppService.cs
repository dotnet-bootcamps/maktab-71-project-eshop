
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
        Task Set(ProductDto model);
        Task Update(ProductDto model);
        Task Delete(int id);
    }
}
