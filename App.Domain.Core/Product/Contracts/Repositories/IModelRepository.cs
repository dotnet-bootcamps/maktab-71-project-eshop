using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IModelRepository
    {
        Model GetById(int Id);
        List<Model> GetAll();
        int Create(Model model);
        void Update(Model model);
        bool Remove(int Id);
    }
}
