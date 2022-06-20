using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ModelCommandRepository : IModelRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Create(Model model)
        {
            _appDbContext.Models.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;
        }
        public void Update(Model model)
        {
            var record = _appDbContext.Models.FirstOrDefault(x => x.Id == model.Id);
            record.Name = model.Name;
            record.BrandId = model.BrandId;
            _appDbContext.SaveChanges();
        }
        public bool Remove(int id)
        {
            var record = _appDbContext.Models.FirstOrDefault(p => p.Id == id);
            _appDbContext.Models.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Model> GetAll()
        {
            var record = _appDbContext.Models.ToList();
            return record;
        }

        public Model GetById(int id)
        {
            var record = _appDbContext.Models.FirstOrDefault(p => p.Id == id);
            return record;
        }

        public Model GetByName(string name)
        {
            var record = _appDbContext.Models.FirstOrDefault(p => p.Name == name);
            return record;
        }
    }
}
