using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAggrigate.Contracts.Repositories
{
    public interface IBrandRepository
    {
        Brand GetBy(int Id);
        List<Brand> GetAll();
        void Create(Brand brand);
        void Update(Brand brand);
        void Remove(int Id);
    }
}
