using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Category
{
    public interface ICategoryCommandRepository
    {
        Task Add(CategorySaveDto dto);
        void Update(CategorySaveDto dto);
        void Delete(int id);
    }
}
