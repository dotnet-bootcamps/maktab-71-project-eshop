using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Color
{
    public interface IColorQueryRepository
    {
        Task<List<ColorDto>> GetAll();
        Task<ColorDto> Get(int id);
        Task<ColorDto> Get(string name);
    }
}
