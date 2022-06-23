using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductCommandRepository
    {
        Task AddProduct(CreateProductDto command);
        void UpdateProduct(UpdateProductDto command);
        void DeleteProduct(int id);
    }
}
