using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
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
