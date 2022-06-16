using OperatorEntities = App.Domain.Core.Operator.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Operator.Contracts.Repositories;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly AppDbContext _dbContext;
        public OperatorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(OperatorEntities.Operator shopOperator)
        {
            _dbContext.Add(shopOperator);
            _dbContext.SaveChanges();
            
        }
        public void Update(OperatorEntities.Operator shopOperator)
        {
            _dbContext.Update(shopOperator);
            _dbContext.SaveChanges();

        }

        public List<OperatorEntities.Operator> GetAll()
        {
            List<OperatorEntities.Operator> OperatorList = _dbContext.Operators.ToList();
            return OperatorList;
        }

        public OperatorEntities.Operator GetById(int id)
        {
            var op = _dbContext.Operators.Find(id);
            return op;
        }

        public void Remove(int id)
        {
            var op = _dbContext.Operators.SingleOrDefault(x => x.Id == id);
            _dbContext.Operators.Remove(op);
            _dbContext.SaveChanges();
            
        }
    }
}
