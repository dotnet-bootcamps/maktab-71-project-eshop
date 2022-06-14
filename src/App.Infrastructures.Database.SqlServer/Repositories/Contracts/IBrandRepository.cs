using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
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
