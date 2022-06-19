using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductRepository
    {
        App.Domain.Core.Product.Entities.Product GetById(int Id);
        List<App.Domain.Core.Product.Entities.Product> GetAll();
        int Create(App.Domain.Core.Product.Entities.Product model);
        void Update(App.Domain.Core.Product.Entities.Product model);
        bool Remove(int Id);
        App.Domain.Core.Product.Entities.Product GetExitingProduct(string name, int categoryId, int brandId, int modelId);

    }
}
