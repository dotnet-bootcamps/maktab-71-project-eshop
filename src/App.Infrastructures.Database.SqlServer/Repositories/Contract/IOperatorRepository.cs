using App.Infrastructures.Database.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contract
{
    public interface IOperatorRepository
    {
        List<Operator> GetAll();
        Operator GetById(int id);
        void Add(Operator @operator);
        void Remove(int id);
        
    }
}
