

using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();
        Task<ProductDTO> Get(int id);
        Task<ProductDTO> Get(string name);

        Task AddProduct(ProductDTO model);

        Task UpdateProduct(ProductDTO model);

        Task DeleteProduct(ProductDTO model);


        List<CategoryDTO> GetAllCategories();
        List<BrandDto> GetAllBrands();
        List<ColorDTO> GetAllColors();
        List<ModelDTO> GetAllModels();

        Task EnsureProductDoseNotExist(string name);
        Task EnsureProductExist(string name);
        Task EnsureProductExist(int id);
    }
}
