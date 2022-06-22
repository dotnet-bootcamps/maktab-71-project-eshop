using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandCommandRepository
    {
        Task<int> Add(string name, int displayOrder, DateTime creationDate, bool isDeleted);
        Task Update(int id, string name, int displayOrder);
        Task Remove(int Id);
    }
}
