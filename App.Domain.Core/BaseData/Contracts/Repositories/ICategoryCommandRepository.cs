using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICategoryCommandRepository
    {
        Task<int> Add(string name, int displayOrder, DateTime creationDate,int ParentCagetoryId, bool isDeleted,bool isActive);
        Task Update(int id, string name, int displayOrder, int ParentCagetoryId, bool isDeleted, bool isActive);
        Task Remove(int Id);
    }
}
