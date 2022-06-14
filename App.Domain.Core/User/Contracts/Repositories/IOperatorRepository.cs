using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IOperatorRepository
    {
        Operator GetById(int Id);
        List<Operator> GetAll();
        int Create(Operator model);
        void Update(Operator model);
        bool Remove(int Id);

    }
}
