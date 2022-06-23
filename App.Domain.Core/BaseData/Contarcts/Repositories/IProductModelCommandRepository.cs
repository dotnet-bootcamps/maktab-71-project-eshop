using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IProductModelCommandRepository
    {
        Task AddProductModel(string name, int brandId, int ParentModelId, DateTime creationDate, bool isDeleted);
         void UpdateProductModel(int id, string name, int brandId, int ParentModelId);
        void DeleteProductModel(int id);
    }
}
