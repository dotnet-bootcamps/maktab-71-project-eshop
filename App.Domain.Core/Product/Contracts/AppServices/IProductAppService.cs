using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name, int brandId, int categoryId, int modelId);
        Task<int> Create(ProductInputDto product, int operatorId);
        Task Update(ProductUpdateDto product);
        Task Delete(int id);
    }
}
