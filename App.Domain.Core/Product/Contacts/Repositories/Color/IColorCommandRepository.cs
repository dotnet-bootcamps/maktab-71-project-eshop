using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Color
{
    public interface IColorCommandRepository
    {
        Task Add(ColorDto dto);
        Task Update(ColorDto dto);
        Task Delete(int id);
    }
}
