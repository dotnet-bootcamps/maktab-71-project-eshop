using productEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface IProductRepository
    {
        public void Create(productEntities.Product product);
        public void Edit(productEntities.Product model);
        public void Delete(int id);
        public List<productEntities.Product> GetAll();
        public productEntities.Product GetById(int id);

    }
}
