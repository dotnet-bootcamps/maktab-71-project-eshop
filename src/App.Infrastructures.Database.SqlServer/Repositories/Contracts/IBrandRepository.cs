using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IBrandRepository
    {
        Brand GetById(int Id);
        List<Brand> GetAll();
        int Create(Brand model);
        void Update(Brand model);
        bool Remove(int Id);
    }
}
