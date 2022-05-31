﻿using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories.contract;


namespace App.Infrastructures.Database.SqlServer.Ripository
{
    public class ProductRepository:IProductRepository
    {
        public AppDbContext _eShop = new();
        public void Add(Product product)
        {
            _eShop.Products.Add(product);
            _eShop.SaveChanges();
        }
        public void Update(Product model)
        {
            var product = _eShop.Products.FirstOrDefault(p => p.Id == model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Weight = model.Weight;
            product.Price = model.Price;
            product.Count = model.Count;
            product.IsActive = model.IsActive;
            product.CreationDate = model.CreationDate;
            _eShop.SaveChanges();

        }

        public void Remove(int id)
        {
            var product = _eShop.Products.FirstOrDefault(p => p.Id == id);
            _eShop.Products.Remove(product);
            _eShop.SaveChanges();

        }

        public List<Product> GetAll()
        {
            return _eShop.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _eShop.Products.First(p => p.Id == id);
        }
    }
}