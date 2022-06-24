using App.Domain.Core.Operator.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Operator.Contract.Services
{
    public interface IOperatorService
    {
        Task<List<OperatorDto>> GetAll();
        Task Set(OperatorDto dto);
        Task<OperatorDto> Get(int id);
        Task<OperatorDto> Get(string name);
        Task Update(OperatorDto dto);
        Task Delete(int id);
        Task EnsureDoesNotExist(string name);
        Task EnsureExists(string name);
        Task EnsureExists(int id);
    }
}
