using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ModelService : IModelService
    {
        private readonly IModelCommandRepository _modelCommandRepository;
        private readonly IModelQueryRepository _modelQueryRepository;

        public ModelService(IModelCommandRepository modelCommandRepository
            ,IModelQueryRepository modelQueryRepository)
        {
            _modelCommandRepository = modelCommandRepository;
            _modelQueryRepository = modelQueryRepository;
        }
        //Commands :
        public async Task<int> Create(string name, int parentModelId,int brandId)
        {
            var id = await _modelCommandRepository.Add(name, parentModelId, brandId, DateTime.Now, false);
            return id;
        }

        public async Task Delete(int id)
        {
            await _modelCommandRepository.Remove(id);
        }
        public async Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted)
        {
            await _modelCommandRepository.Update(id, name, parentModelId, brandId, isDeleted);
        }

        //Queries :

        public async Task<ModelDto?> Get(int id)
        {
            var model=await _modelQueryRepository.Get(id);
            return model;
        }

        public async Task<ModelDto?> Get(string name)
        {
            var model = await _modelQueryRepository.Get(name);
            return model;
        }

        public async Task<List<ModelDto>> GetAll()
        {
            var models = await _modelQueryRepository.GetAll();
            return models;
        }

        
        public async Task EnsureModelIsExist(string name)
        {
            var model = await _modelQueryRepository.Get(name);
            if (model == null)
                throw new Exception($"There is no Model with Name:{ name }");
        }

        public async Task EnsureModelIsExist(int id)
        {
            var model = await _modelQueryRepository.Get(id);
            if (model == null)
                throw new Exception($"There is no Model with Id:{ id }");
        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var model = await _modelQueryRepository.Get(name);
            if (model != null)
                throw new Exception($"There is a Model with Name:{ name }");
        }
    }
}
