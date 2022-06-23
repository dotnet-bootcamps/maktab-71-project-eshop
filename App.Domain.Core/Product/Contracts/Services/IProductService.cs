using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        //Query
        Task<List<ProductDto>> GetAll();
        Task<ProductDto?> Get(int id);
        Task<ProductDto?> Get(string name, int brandId, int categoryId, int modelId);

        //Command
        Task<int> Create(ProductInputDto product, int operatorId);
        Task Delete(int id);
        Task Update(ProductUpdateDto product);

        //Ensurness
        Task EnsureProductIsNotExist(string name, int brandId, int categoryId, int modelId);
        Task EnsureProductIsExist(string name, int brandId, int categoryId, int modelId);
        Task EnsureProductIsExist(int id);
    }
}
