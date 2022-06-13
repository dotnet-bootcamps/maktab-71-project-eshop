using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAggrigate.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Category GetBy(int Id);
        List<Category> GetAll();
        void Create(Category brand);
        void Update(Category brand);
        void Remove(int Id);
    }
}
