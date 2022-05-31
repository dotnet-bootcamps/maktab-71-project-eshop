using App.Infrastructures.Database.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contract
{
    public interface IBrandRepository
    {
        void Add(Brand brand);
        Brand GetById(int id);
        List<Brand> GetAll();
        void Remove(int id);
        void Update(Brand brand);
    }
}
