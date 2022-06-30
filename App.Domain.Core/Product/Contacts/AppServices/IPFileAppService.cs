using App.Domain.Core.Product.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IPFileAppService
    {
        Task<List<PFileDto>> GetAll();
        Task Set(PFileDto dto);
        Task<PFileDto> Get(int id);
        Task<PFileDto> Get(string name);
        Task Update(PFileDto dto);
        Task Delete(int id);
    }
}
