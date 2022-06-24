using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();

        Task SetProduct(int categoryId, int brandId, decimal Weight, bool IsOrginal, string description, int count,
            int modelId,long price,int operatorId,bool isShowPrice,string name);

        ProductDto GetProduct(int id);
        ProductDto GetProduct(string name);
        void UpdateProduct(int id, int categoryId, int brandId, decimal Weight, bool IsOrginal, string description, int count,
            int modelId, long price, int operatorId, bool isShowPrice, string name);
        void DeleteProduct(int id);
        void EnsureProductDoseNotExist(string name);
        void EnsureProductExist(string name);
        void EnsureProductExist(int id);
    }
}