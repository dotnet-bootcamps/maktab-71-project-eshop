using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ModelAppService : IModelAppService
    {
        private readonly IModelService _modelService;
        private readonly IPermissionService _permissionService;

        public ModelAppService(IModelService modelService
            , IPermissionService permissionService)
        {
            _modelService = modelService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(string name, int parentModelId, int brandId)
        {
            await _modelService.EnsureModelIsNotExist(name);
            var id = await _modelService.Create(name, parentModelId, brandId);
            return id;
        }

        public async Task Delete(int id)
        {
            await _modelService.EnsureModelIsExist(id);
            await _modelService.Delete(id);
        }
        public async Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted)
        {
            await _modelService.EnsureModelIsExist(id);
            await _modelService.Update(id, name, parentModelId, brandId, isDeleted);
        }
        public async Task<ModelDto> Get(int id)
        {
            await _modelService.EnsureModelIsExist(id);
            var model=await _modelService.Get(id);
            return model;
        }

        public async Task<ModelDto> Get(string name)
        {
            await _modelService.EnsureModelIsExist(name);
            var model = await _modelService.Get(name);
            return model;
        }

        public async Task<List<ModelDto>> GetAll()
        {
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewModels);
            var models=await _modelService.GetAll();
            return models;
        }

        
    }
}
