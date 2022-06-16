using ProductEntity = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductRepository
    {
        public void Create(ProductEntity.Product product);
        public void Edit(ProductEntity.Product model);
        public void Delete(int id);
        public List<ProductEntity.Product> GetAll();
        public ProductEntity.Product GetById(int id);

    }
}
