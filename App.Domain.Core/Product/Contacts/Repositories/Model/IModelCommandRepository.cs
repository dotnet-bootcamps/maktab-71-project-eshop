using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Model
{
    public interface IModelCommandRepository
    {
        Task Add(ModelDto dto);
        Task Update(ModelDto dto);
        Task Delete(int id);
    }
}
