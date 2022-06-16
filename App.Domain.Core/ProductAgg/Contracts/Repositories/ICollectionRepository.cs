using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.Contracts.Repositories
{
    public interface ICollectionRepository
    {
        Collection GetById(int id);
        List<Collection> GetAll();
        void Add(Collection item);
        void Update(Collection item);
        void Remove(Collection item);
    }
}
