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
        Task<int> Add(string name,DateTime creationDate,bool isDeleted);
        Task Update(int id, string name, bool isDeleted);
        Task Remove(int Id);
    }
}
