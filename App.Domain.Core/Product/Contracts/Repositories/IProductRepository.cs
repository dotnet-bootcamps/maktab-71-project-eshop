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
        public void Create(App.Domain.Core.Product.Entities.Product product);
        public void Edit(App.Domain.Core.Product.Entities.Product model);
        public void Delete(int id);
        public List<App.Domain.Core.Product.Entities.Product> GetAll();
        public App.Domain.Core.Product.Entities.Product GetById(int id);

    }
}
