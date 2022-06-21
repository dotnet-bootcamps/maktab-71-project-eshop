using App.Domain.Core.Operator.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operator.Contract.Repositories
{
    public interface IOperatorQueryRepository
    {
        Task<List<OperatorDto>> GetAll();
        Task<OperatorDto>? Get(int id);
        Task<OperatorDto>? Get(string name);
    }
}
