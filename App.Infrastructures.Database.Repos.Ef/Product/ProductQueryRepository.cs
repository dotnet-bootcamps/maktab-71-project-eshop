using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Dtos;
using Productentity = App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
           _context = context;
        }
        public List<ProductDto> GetAllProduct()
        {
            return _context.Products.AsNoTracking().Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Count = p.Count,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                Description = p.Description,
                CreationDate_Miladi = p.CreationDate.MiladiToshamsi(),
            }).ToList();
        }

        public void DeleteProduct(int id)
        {
            var P = getproduct(id);
            _context.Products.Remove(P);
        }

        public Productentity.Product? getproduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
          
        }

        public void SetProduct(ProductDto Pitem)
        {

           var p = new Product
           {
               Id = Pitem.Id,

           }
            _context.Products.Add(Pitem);
        }
    }
}

