using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class BrandRepository
    {
        private readonly AppDbContext _eshop;
        public BrandRepository(AppDbContext appDbContext)
        {
            this._eshop = appDbContext;
        }

        public void Create(Brand brand)
        {
            _eshop.Brands.Add(brand);
            _eshop.SaveChanges();
        }

        public void Edit(Brand model)
        {
            var brand = _eshop.Brands.First(p => p.Id == model.Id);
            brand.Name = model.Name;
            brand.DisplayOrder = model.DisplayOrder;
            brand.CreationDate = model.CreationDate;
            _eshop.SaveChanges();
        }

        public void Delete(int id)
        {
            var brand = _eshop.Brands.First(p => p.Id == id);
            _eshop.Brands.Remove(brand);
            _eshop.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return _eshop.Brands.Include(b => b.Products).ToList();
        }

        public Brand GetById(int id)
        {
            return _eshop.Brands.First(p => p.Id == id);
        }
    }
}


