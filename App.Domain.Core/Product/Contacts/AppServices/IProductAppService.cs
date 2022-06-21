
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductOutputDto>> GetAll(int operatorId);
        Task<ProductOutputDto> Get(int operatorId, int id);
        Task<ProductOutputDto> Get(int operatorId, string name);
        Task Add(ProductInputDto product);
        Task Update(int id, ProductInputDto product, bool isDeleted);
        Task Delete(int operatorId, int id);
    }
}
