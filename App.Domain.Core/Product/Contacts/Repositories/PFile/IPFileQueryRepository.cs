using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.PFile
{
    public interface IPFileQueryRepository
    {
        Task<List<PFileDto>> GetAll();
        Task<PFileDto>? Get(int id);
        Task<PFileDto>? Get(string name);
    }
}
