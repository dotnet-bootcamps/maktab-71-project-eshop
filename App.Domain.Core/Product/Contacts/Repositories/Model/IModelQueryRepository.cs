using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Color
{
    public interface IModelQueryRepository
    {
        Task<List<ModelDto>> GetAll();
        Task<ModelDto> Get(int id);
        Task<ModelDto> Get(string name);
    }
}
