using operatorEntities = App.Domain.Core.Operator.Entities;


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
