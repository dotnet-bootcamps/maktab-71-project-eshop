using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICollectionCommandRepository
    {
        Collection GetById(int Id);
        Collection GetByName(string name);
        List<Collection> GetAll();
        int Create(Collection model);
        void Update(Collection model);
        bool Remove(int Id);
    }
}
