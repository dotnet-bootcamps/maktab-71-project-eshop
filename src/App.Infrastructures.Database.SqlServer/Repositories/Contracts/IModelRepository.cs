using App.Domain.Core.BaseData_Aggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IModelRepository
    {
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
        List<Model> GetAll();
        Model GetById(int id);
    }
}
