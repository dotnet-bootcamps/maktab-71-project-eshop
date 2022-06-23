using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ITagCommandRepository 
    {
        Task<int> Add(string name, int tagCategoryId,bool hasValue, DateTime creationDate, bool isDeleted);
        Task Update(int id, string name, int tagCategoryId, bool hasValue,bool isDeleted);
        Task Remove(int Id);
    }
}
