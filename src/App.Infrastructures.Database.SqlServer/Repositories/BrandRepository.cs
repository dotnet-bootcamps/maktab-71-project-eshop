using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Domain.Core.ProductAgg.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructures.Database.SqlServer.Repositories
{

    public class BrandRepository: IBrandRepository
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

        public void Update(Brand brand)
        {
            _eshop.Brands.Update(brand);
        }

        public void Remove(int id)
        {
            var brand = _eshop.Brands.First(p => p.Id == id);
            _eshop.Brands.Remove(brand);
            _eshop.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return _eshop.Brands.Include(b => b.Products).ToList();
        }

        public Brand GetBy(int id)
        {
            return _eshop.Brands.First(p => p.Id == id);
        }

        public bool Exists(string name)
        {
            return _eshop.Brands.Any(p => p.Name == name);
        }
        public bool Exists(int id)
        {
            return _eshop.Brands.Any(p => p.Id == id);
        }
    }
}


