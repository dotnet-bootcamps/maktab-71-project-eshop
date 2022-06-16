using App.Domain.Core.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.Contracts.Repositories
{
    public interface IOperatorRepository
    {
        List<Operator> GetAll();
        Operator GetById(int id);
        void Add(Operator @operator);
        void Remove(int id);

    }
}
