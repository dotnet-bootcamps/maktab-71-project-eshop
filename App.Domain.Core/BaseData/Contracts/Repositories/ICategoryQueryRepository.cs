using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICategoryQueryRepository
    {
        Category GetById(int Id);
        Category GetByName(string name);
        List<Category> GetAll();
        int Create(Category model);
        void Update(Category model);
        bool Remove(int Id);
    }
}
