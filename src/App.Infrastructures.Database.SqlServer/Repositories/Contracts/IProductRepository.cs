using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IProductRepository
    {
        Product GetById(int Id);
        List<Product> GetAll();
        int Create(Product model);
        void Update(Product model);
        bool Remove(int Id);

    }
}
