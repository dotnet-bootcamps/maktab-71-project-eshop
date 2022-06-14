using brandEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface IBrandRepository
    {
        brandEntities.Brand GetBy(int Id);
        List<brandEntities.Brand> GetAll();
        void Create(brandEntities.Brand brand);
        void Update(brandEntities.Brand brand);
        void Remove(int Id);
    }
}
