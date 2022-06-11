using App.EndPoints.Mvc.AdminUI.ViewModels;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.Infrastructures.Database.SqlServer.ViewModels.Color;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ColorRepository : IColorRepository
    {

        private readonly AppDbContext _eshop;

        public ColorRepository(AppDbContext appDbContext)
        {
            _eshop = appDbContext;
        }

        public void Create(ColorSaveViewModel model)
        {
            var color = new Color
            {
                Code = model.Code,
                Name = model.Name,
                CreationDate = DateTime.Now,
                IsDeleted = model.IsDeleted,
            };
            _eshop.Colors.Add(color);
            _eshop.SaveChanges();
        }
        public void Update(ColorSaveViewModel model)
        {
            var color = _eshop.Colors.First(p => p.Id == model.Id);
            color.Name = model.Name;
            color.Code = model.Code;
            _eshop.SaveChanges();
        }
        public void Delete(int id)
        {
            var color = _eshop.Colors.First(p => p.Id == id);
            _eshop.Colors.Remove(color);
            _eshop.SaveChanges();
        }


        public List<ColorListViewModel> GetAll()
        {
            return _eshop.Colors.Select(b => new ColorListViewModel
            {
                Id = b.Id,
                Name = b.Name,
                CreationDate = b.CreationDate,
                Code = b.Code,
                IsDeleted = b.IsDeleted,
            }).ToList();
        }
        public ColorSaveViewModel GetById(int id)
        {
            try
            {
                var model = _eshop.Colors.Select(b => new ColorSaveViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    IsDeleted = b.IsDeleted,
                }).SingleOrDefault(b => b.Id == id);
                if (model == null) return new ColorSaveViewModel();
                return model;
            }
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
        }
    }
}
