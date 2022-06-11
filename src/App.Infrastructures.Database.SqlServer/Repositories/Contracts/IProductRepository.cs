using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IProductRepository
    {
        public void Create(ProductSaveViewModel product);
        public void Update(ProductSaveViewModel model);
        public void Delete(int id);
        public List<ProductListViewModel> GetAll();
        public ProductSaveViewModel GetById(int id);

    }
}
