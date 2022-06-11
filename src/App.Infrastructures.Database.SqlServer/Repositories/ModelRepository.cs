using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.Infrastructures.Database.SqlServer.ViewModels.Model;
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

        public void Create(ModelSaveViewModel model)
        {

            var record = new Model
            {
                Name = model.Name,
                ParentModelId = model.ParentModelId,
                BrandId = model.BrandId,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };
            _appDbContext.Models.Add(record);
            _appDbContext.SaveChanges();
        }

        public void Update(ModelSaveViewModel model)
        {
            var record = _appDbContext.Models.FirstOrDefault(p => p.Id == model.Id);
            if (record == null) return;
            record.Name = model.Name;
            record.IsDeleted = model.IsDeleted;
            record.ParentModelId = model.ParentModelId;
            record.BrandId = model.BrandId;
            _appDbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var record = _appDbContext.Models.FirstOrDefault(p => p.Id == id);
            if (record == null) return;
            _appDbContext.Models.Remove(record);
            _appDbContext.SaveChanges();
        }

        public List<ModelListViewModel> GetAll()
        {
            return _appDbContext.Models.Select(b => new ModelListViewModel
            {
                Id = b.Id,
                Name = b.Name,
                CreationDate = b.CreationDate,
                ParentModelId = b.ParentModelId,
                BrandId = b.BrandId,
                IsDeleted = b.IsDeleted,
            }).ToList();
        }

        public ModelSaveViewModel GetById(int id)
        {
            try
            {
                var model = _appDbContext.Models.Select(b => new ModelSaveViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    ParentModelId = b.ParentModelId,
                    BrandId = b.BrandId,
                    IsDeleted = b.IsDeleted,
                }).SingleOrDefault(b => b.Id == id);
                if (model == null) return new ModelSaveViewModel();
                return model;
            }
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
        }
    }
}
