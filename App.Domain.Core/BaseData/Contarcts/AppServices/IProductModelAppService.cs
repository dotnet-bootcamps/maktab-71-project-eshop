using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.AppServices
{
    public interface IProductModelAppService
    {
        Task<List<ProductModelDto>> GetProductModels();
        Task SetProductModel(string name, int parentModelId, int brandId);
        ProductModelDto GetProductModel(int id);
        ProductModelDto GetProductModel(string name);
        void UpdateProductModel(int id, string name, int parentModelId, int brandId);
        void DeleteProductModel(int id);
    }
}
