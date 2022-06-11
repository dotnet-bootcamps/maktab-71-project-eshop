using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IModelRepository
    {
        ModelSaveViewModel GetById(int Id);
        List<ModelListViewModel> GetAll();
        void Create(ModelSaveViewModel brand);
        void Update(ModelSaveViewModel brand);
        void Remove(int Id);
    }
}
