using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;

namespace App.Infrastructures.Database.SqlServer.Repositories
{

    public class BrandRepository : IBrandRepository
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

        public void Update(Brand model)
        {
            var brand = _eshop.Brands.First(p => p.Id == model.Id);
            brand.Name = model.Name;
            brand.DisplayOrder = model.DisplayOrder;
            brand.CreationDate = model.CreationDate;
            _eshop.SaveChanges();
        }

        public void Remove(int id)
        {
            var brand = _eshop.Brands.First(p => p.Id == id);
            _eshop.Brands.Remove(brand);
            _eshop.SaveChanges();
        }

        public List<BrandDto> GetAll()
        {
            return _eshop.Brands.Select(b => new BrandDto()
            {
                Name = b.Name,
                DisplayOrder = b.DisplayOrder,
                CreationDate = b.CreationDate,
                Id = b.Id
            }).ToList();
        }

        public BrandDto GetBy(int id)
        {
            return _eshop.Brands.Select(b => new BrandDto()
            {
                Name = b.Name,
                DisplayOrder = b.DisplayOrder,
                CreationDate = b.CreationDate,
                Id = b.Id
            }).FirstOrDefault(p => p.Id == id);
        }

        public BrandDto GetBy(string name)
        {
            return _eshop.Brands.Select(b => new BrandDto()
            {
                Name = b.Name,
                DisplayOrder = b.DisplayOrder,
                CreationDate = b.CreationDate,
                Id = b.Id
            }).FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }
    }
}


