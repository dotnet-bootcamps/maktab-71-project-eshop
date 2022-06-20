using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionCommandRepository _collectionRepository;

        public CollectionService(ICollectionCommandRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }
        public void EnsureCollectionIsNotExist(string name)
        {
            var record = _collectionRepository.GetByName(name);
            if (record is not null)
                throw new Exception("Collection Is Already Exist");
        }
    }
}
