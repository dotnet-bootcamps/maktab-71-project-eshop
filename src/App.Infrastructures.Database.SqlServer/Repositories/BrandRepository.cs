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

    public class BrandRepository: IBrandRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Create(Brand model)
        {
            _appDbContext.Brands.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;
        }

        public void Update(Brand model)
        {
            var record = _appDbContext.Brands.FirstOrDefault(p => p.Id == model.Id);
            record.Name = model.Name;
            record.DisplayOrder = model.DisplayOrder;
            record.CreationDate = model.CreationDate;
            _appDbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var record = _appDbContext.Brands.FirstOrDefault(p => p.Id == id);
            _appDbContext.Brands.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Brand> GetAll()
        {
            var record = _appDbContext.Brands.ToList();
            return record;
        }

        public Brand GetById(int id)
        {
            var record = _appDbContext.Brands.FirstOrDefault(p => p.Id == id);
            return record;
        }

        public Brand GetByName(string name)
        {
            var record = _appDbContext.Brands.FirstOrDefault(p => p.Name == name);
            return record;
        }
    }
}


