using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IColorAppService
    {
        Task<List<ColorDto>> GetAll();
        Task Set(ColorDto dto);
        Task<ColorDto> Get(int id);
        Task<ColorDto> Get(string name);
        Task Update(ColorDto dto);
        Task Delete(int id);
    }
}
