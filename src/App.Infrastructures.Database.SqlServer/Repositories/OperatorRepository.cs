using App.Domain.Core.UserAgg.Contracts.Repositories;
using App.Domain.Core.UserAgg.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly AppDbContext _dbContext;
        public OperatorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Operator shopOperator)
        {
            _dbContext.Add(shopOperator);
            _dbContext.SaveChanges();
            
        }
        public void Update(Operator shopOperator)
        {
            _dbContext.Update(shopOperator);
            _dbContext.SaveChanges();

        }

        public List<Operator> GetAll()
        {
            List<Operator> OperatorList = _dbContext.Operators.ToList();
            return OperatorList;
        }

        public Operator GetById(int id)
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
