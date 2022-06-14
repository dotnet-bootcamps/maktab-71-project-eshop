using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeoductEntities=App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface IProductRepository
    {
        public void Create(PeoductEntities.Product product);
        public void Edit(PeoductEntities.Product model);
        public void Delete(int id);
        public List<PeoductEntities.Product> GetAll();
        public PeoductEntities.Product GetById(int id);

    }
}
