using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ProductModelService : IProductModelService
    {
        private readonly IProductModelCommandRepository _ProductModelCommandRepository;
        private readonly IProductModelQueryRepository _ProductModelQueryRepository;

        public ProductModelService(IProductModelCommandRepository productModelCommandRepository,
            IProductModelQueryRepository productModelQueryRepository)
        {
            _ProductModelCommandRepository = productModelCommandRepository;
            _ProductModelQueryRepository = productModelQueryRepository;
        }

        public void DeleteProductModel(int id)
        {
            _ProductModelCommandRepository.DeleteProductModel(id);
        }

        public void EnsureProductModelDoseNotExist(string name)
        {
            var productModel = _ProductModelQueryRepository.GetProductModel(name);
            if (productModel != null)
                throw new Exception($"there is a productModel with name = {name}");
        }

        public void EnsureProductModelExist(string name)
        {
            var productModel = _ProductModelQueryRepository.GetProductModel(name);
            if (productModel == null)
                throw new Exception($"there is no productModel with name = {name}");
        }

        public void EnsureProductModelExist(int id)
        {
            var productModel = _ProductModelQueryRepository.GetProductModel(id);
            if (productModel == null)
                throw new Exception($"there is no productModel with id = {id}");
        }

        public ProductModelDto GetProductModel(int id)
        {
            var productModel = _ProductModelQueryRepository.GetProductModel(id);
            if (productModel == null)
                throw new Exception($"there is no productModel with id = {id}");
            return productModel;
        }

        public ProductModelDto GetProductModel(string name)
        {
            var productModel = _ProductModelQueryRepository.GetProductModel(name);
            if (productModel == null)
                throw new Exception($"there is no productModel with name = {name}");
            return productModel;
        }

        public async Task<List<ProductModelDto>> GetProductModels()
            => await _ProductModelQueryRepository.GetAllProductModel();


        public async Task SetProductModel(string name, int parentModelId, int brandId)
        {
            await _ProductModelCommandRepository.AddProductModel(name, brandId, parentModelId, DateTime.Now, false);
        }

        public void UpdateProductModel(int id, string name, int parentModelId, int brandId)
        {
            _ProductModelCommandRepository.UpdateProductModel(id,name,brandId,parentModelId);
        }

 
    }
}
