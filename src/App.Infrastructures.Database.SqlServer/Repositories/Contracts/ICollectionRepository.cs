using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface ICollectionRepository
    {
        Collection GetById(int Id);
        List<Collection> GetAll();
        int Create(Collection model);
        void Update(Collection model);
        bool Remove(int Id);
    }
}
