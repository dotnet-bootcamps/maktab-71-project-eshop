using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
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
        AppDbContext _context = new();
        public void Add(Model model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var model = _context.Models.SingleOrDefault(x => x.Id == id);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }

            
        }

        public List<Model> GetAll()
        {
            return _context.Models.ToList();
        }

        public Model GetById(int id)
        {
            var model = _context.Models.FirstOrDefault(x => x.Id == id);
            if (model is null)
            {
                return new Model();
            }
            return model;
        }

        public void Update(Model model)
        {
            var dbModel = _context.Models.SingleOrDefault(x => x.Id == model.Id);
            dbModel = model;
            _context.SaveChanges();
        }
    }
}
