using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IModelCommandRepository
    {
        Task<int> Add(string name, int parentModelId, int brandId,DateTime creationDate, bool isDeleted);
        Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted);
        Task Remove(int Id);
    }
}
