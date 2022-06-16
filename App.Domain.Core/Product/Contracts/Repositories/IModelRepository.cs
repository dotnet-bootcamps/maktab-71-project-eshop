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
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
        List<Model> GetAll();
        Model GetById(int id);
    }
}
