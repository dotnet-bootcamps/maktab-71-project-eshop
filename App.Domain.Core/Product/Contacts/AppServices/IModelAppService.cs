using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IModelAppService
    {
        Task<List<ModelDto>> GetAll();
        Task Set(ModelDto dto);
        Task<ModelDto> Get(int id);
        Task<ModelDto> Get(string name);
        Task Update(ModelDto dto);
        Task Delete(int id);
    }
}
