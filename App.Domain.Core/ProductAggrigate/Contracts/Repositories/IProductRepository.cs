using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAggrigate.Contracts.Repositories
{
    public interface IProductRepository
    {
        public void Create(Product product);
        public void Edit(Product model);
        public void Delete(int id);
        public List<Product> GetAll();
        public Product GetById(int id);

    }
}
