using modelEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface IModelRepository
    {
        void Add(modelEntities.Model model);
        void Update(modelEntities.Model model);
        void Delete(int id);
        List<modelEntities.Model> GetAll();
        modelEntities.Model GetById(int id);
    }
}
