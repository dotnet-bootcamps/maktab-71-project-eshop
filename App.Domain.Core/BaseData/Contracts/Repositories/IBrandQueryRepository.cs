using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
        Brand GetById(int Id);
        Brand GetByName(string name);
        List<Brand> GetAll();
        int Create(Brand model);
        void Update(Brand model);
        bool Remove(int Id);
    }
}
