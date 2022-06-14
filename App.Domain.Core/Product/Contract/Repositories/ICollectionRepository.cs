using collectionEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface ICollectionRepository
    {
        collectionEntities.Collection GetById(int id);
        List<collectionEntities.Collection> GetAll();
        void Add(collectionEntities.Collection item);
        void Update(collectionEntities.Collection item);
        void Remove(collectionEntities.Collection item);
    }
}
