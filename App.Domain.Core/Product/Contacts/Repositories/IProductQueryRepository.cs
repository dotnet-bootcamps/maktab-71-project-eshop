

using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductQueryRepository
    {
        Task<List<ProductOutputDto>> GetAll();
        Task<ProductOutputDto?> Get(int id);
        Task<ProductOutputDto?> Get(string name);
        Task<ProductOutputDto?> Get(int modelId, int categoryId, int brandId);
    }
}
