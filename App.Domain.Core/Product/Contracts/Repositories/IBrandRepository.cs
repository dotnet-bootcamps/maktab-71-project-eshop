using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IBrandRepository
    {
        Brand GetById(int Id);
        Brand GetByName(string name);
        List<Brand> GetAll();
        int Create(Brand model);
        void Update(Brand model);
        bool Remove(int Id);
    }
}
