using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductCommandRepository
    {
        Task AddProduct(int categoryId, int brandId, decimal weight, bool isOrginal, string description, int Count,
            int modelId, long price, bool isShowPrice, bool isActive, int operatorId, string name, DateTime creationDate, bool isDeleted);

        void UpdateProduct(int id, int categoryId, int brandId, decimal weight, bool isOrginal, string description, int Count,
            int modelId, long price, bool isShowPrice, bool isActive, int operatorId, string name, DateTime creationDate, bool isDeleted);
        void DeleteProduct(int id);
    }
}