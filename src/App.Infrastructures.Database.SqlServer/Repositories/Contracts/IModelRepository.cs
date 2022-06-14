using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
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
