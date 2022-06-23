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
    public class CollectionAppService : ICollectionAppService
    {
        private readonly ICollectionService _collectionService;
        private readonly IPermissionService _permissionService;

        public CollectionAppService(ICollectionService collectionService
            , IPermissionService permissionService)
        {
            _collectionService = collectionService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(string name)
        {
            await _collectionService.EnsureCollectionIsNotExist(name);
            var id = await _collectionService.Create(name);
            return id;
        }

        public async Task Delete(int id)
        {
            await _collectionService.EnsureCollectionIsExist(id);
            await _collectionService.Delete(id);
        }
        public async Task Update(int id, string name, bool isDeleted)
        {
            await _collectionService.EnsureCollectionIsExist(id);
            await _collectionService.Update(id, name, isDeleted);
        }
        public async Task<CollectionDto> Get(int id)
        {
            await _collectionService.EnsureCollectionIsExist(id);
            var collection = await _collectionService.Get(id);
            return collection;
        }

        public async Task<CollectionDto> Get(string name)
        {
            await _collectionService.EnsureCollectionIsExist(name);
            var collection = await _collectionService.Get(name);
            return collection;
        }

        public async Task<List<CollectionDto>> GetAll()
        {
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewCollections);
            var collections=await _collectionService.GetAll();
            return collections;
        }

        
    }
}
