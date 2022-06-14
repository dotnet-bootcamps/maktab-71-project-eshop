using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.BaseData_Aggregate.Entities;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Model model)
        {
            _appDbContext.Add(model);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _appDbContext.Models.SingleOrDefault(x => x.Id == id);
            _appDbContext.SaveChanges();
        }

        public List<Model> GetAll()
        {
            return _appDbContext.Models.ToList();
        }

        public Model GetById(int id)
        {
            var model = _appDbContext.Models.FirstOrDefault(x => x.Id == id);
            if (model is null)
            {
                return new Model();
            }
            return model;
        }

        public void Update(Model model)
        {
            var dbModel = _appDbContext.Models.SingleOrDefault(x => x.Id == model.Id);
            dbModel = model;
            _appDbContext.SaveChanges();
        }
    }
}
