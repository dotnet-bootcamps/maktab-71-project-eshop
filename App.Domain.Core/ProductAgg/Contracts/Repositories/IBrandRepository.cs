using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.Contracts.Repositories
{
    public interface IBrandRepository
    {
        Brand GetBy(int id);
        List<Brand> GetAll();
        void Create(Brand brand);
        void Update(Brand brand);
        void Remove(int id);
        bool Exists(string name);
        bool Exists(int id);
    }
}
