using operatorEntities = App.Domain.Core.Operator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operator.Contract.Repositories
{
    public interface IOperatorRepository
    {
        List<operatorEntities.Operator> GetAll();
        operatorEntities.Operator GetById(int id);
        void Add(operatorEntities.Operator @operator);
        void Remove(int id);

    }
}
