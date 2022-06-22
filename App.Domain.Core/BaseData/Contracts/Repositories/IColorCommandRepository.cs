using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorCommandRepository
    {
        Task<int> Add(string name, string code, DateTime creationDate, bool isDeleted);
        Task Update(int id, string name, string code, bool isDeleted);
        Task Remove(int Id);
    }
}
