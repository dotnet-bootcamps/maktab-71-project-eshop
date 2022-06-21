using App.Domain.Core.Operator.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operator.Contract.Repositories
{
    public interface IOperatorCommandRepository
    {
        Task Add(OperatorDto dto);
        Task Update(OperatorDto dto);
        Task Delete(int id);
    }
}
