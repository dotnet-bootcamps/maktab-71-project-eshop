using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.User
{
    public class OperatorCommandRepository : IOperatorCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public OperatorCommandRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public int Create(Operator model)
        {
            _appDbContext.Operators.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;

        }
        public void Update(Operator model)
        {
            var record = _appDbContext.Operators.FirstOrDefault(p => p.Id == model.Id);
            record.Name = model.Name;
            record.IsDeleted = model.IsDeleted;
            record.CreationDate = model.CreationDate;
            _appDbContext.SaveChanges();
        }
        public bool Remove(int id)
        {
            var record = _appDbContext.Operators.FirstOrDefault(p => p.Id == id);
            _appDbContext.Operators.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Operator> GetAll()
        {
            var record = _appDbContext.Operators.ToList();
            return record;
        }

        public Operator GetById(int id)
        {
            var record = _appDbContext.Operators.FirstOrDefault(p => p.Id == id);
            return record;
        }

    }
}
