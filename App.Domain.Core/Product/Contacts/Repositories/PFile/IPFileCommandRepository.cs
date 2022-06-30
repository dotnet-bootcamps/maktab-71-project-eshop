using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.PFile
{
    public interface IPFileCommandRepository
    {
        Task Add(PFileDto dto);
        Task Update(PFileDto dto);
        Task Delete(int id);
    }
}
