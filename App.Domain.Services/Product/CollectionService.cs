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
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionCommandRepository _collectionCommandRepository;
        private readonly ICollectionQueryRepository _collectionQueryRepository;

        public CollectionService(ICollectionCommandRepository collectionCommandRepository
            , ICollectionQueryRepository collectionQueryRepository)
        {
            _collectionCommandRepository = collectionCommandRepository;
            _collectionQueryRepository = collectionQueryRepository;
        }

        //Commands :
        public async Task<int> Create(string name)
        {
            var id = await _collectionCommandRepository.Add(name,DateTime.Now,false);
            return id;
        }

        public async Task Delete(int id)
        {
            await _collectionCommandRepository.Remove(id);
        }
        public async Task Update(int id, string name, bool isDeleted)
        {
            await _collectionCommandRepository.Update(id, name, isDeleted);
        }
        //Queries :

        public async Task<CollectionDto?> Get(int id)
        {
            var collection=await _collectionQueryRepository.Get(id);
            return collection;
        }

        public async Task<CollectionDto?> Get(string name)
        {
            var collection = await _collectionQueryRepository.Get(name);
            return collection;
        }

        public async Task<List<CollectionDto>> GetAll()
        {
            var collections= await _collectionQueryRepository.GetAll();
            return collections;
        }

        //Ensurness :

        public async Task EnsureCollectionIsExist(string name)
        {
            var collection = await _collectionQueryRepository.Get(name);
            if (collection == null)
                throw new Exception($"There is no collection with Name :{name}");
        }

        public async Task EnsureCollectionIsExist(int id)
        {
            var collection = await _collectionQueryRepository.Get(id);
            if (collection == null)
                throw new Exception($"There is no collection with Id :{id}");
        }

        public async Task EnsureCollectionIsNotExist(string name)
        {
            var collection = await _collectionQueryRepository.Get(name);
            if (collection != null)
                throw new Exception($"There is a collection with Name :{name}");
        }
    } 
}
