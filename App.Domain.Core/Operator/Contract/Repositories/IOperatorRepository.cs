
using OperatorEntities= App.Domain.Core.Operator.Entities;

namespace App.Domain.Core.Operator.Contract.Repositories
{
    public interface IOperatorRepository
    {
        List<OperatorEntities.Operator> GetAll();
        OperatorEntities.Operator GetById(int id);
        void Add(OperatorEntities.Operator @operator);
        void Remove(int id);

    }
}
