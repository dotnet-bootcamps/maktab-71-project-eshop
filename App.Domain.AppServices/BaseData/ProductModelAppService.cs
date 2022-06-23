using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ProductModelAppService: IProductModelAppService
    {
        private readonly IProductModelService _ProductModelService;

        public ProductModelAppService(IProductModelService productModelService)
        {
            _ProductModelService = productModelService;
        }

        public void DeleteProductModel(int id)
        {
            _ProductModelService.EnsureProductModelExist(id);
            _ProductModelService.DeleteProductModel(id);
        }

        public ProductModelDto GetProductModel(int id)
            => _ProductModelService.GetProductModel(id);

        public ProductModelDto GetProductModel(string name)
            => _ProductModelService.GetProductModel(name);

        public Task<List<ProductModelDto>> GetProductModels()
             => _ProductModelService.GetProductModels();

        public async Task SetProductModel(string name, int parentModelId, int brandId)
        {
            _ProductModelService.EnsureProductModelDoseNotExist(name);
            await _ProductModelService.SetProductModel(name, parentModelId, brandId);
        }

        public void UpdateProductModel(int id, string name, int parentModelId, int brandId)
        {
            _ProductModelService.EnsureProductModelExist(id);
            _ProductModelService.UpdateProductModel(id, name, parentModelId, brandId);
        }
    }
}
