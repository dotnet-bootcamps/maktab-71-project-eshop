using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;


namespace App.Infrastructures.Database.SqlServer.Repositories.contract
{
    internal interface IProductRepository
    {

        public void Add(Product product);
        public void Update(Product product);
        public void Remove(int id);
        public List<Product> GetAll();
        public Product GetById(int id);
    }
}