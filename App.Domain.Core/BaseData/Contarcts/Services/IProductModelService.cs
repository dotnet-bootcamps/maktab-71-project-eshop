using App.Domain.Core.BaseData.Dtos;


namespace App.Domain.Core.BaseData.Contarcts.Services
{
    public interface IProductModelService
    {
        Task<List<ProductModelDto>> GetProductModels();
        Task SetProductModel(string name,int parentModelId,int brandId);
        ProductModelDto GetProductModel(int id);
        ProductModelDto GetProductModel(string name);
        void UpdateProductModel(int id, string name, int parentModelId, int brandId);
        void DeleteProductModel(int id);
        void EnsureProductModelDoseNotExist(string name);
        void EnsureProductModelExist(string name);
        void EnsureProductModelExist(int id);
    }
}
