using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ITagQueryRepository
    {
        Task<TagDto?> Get(int Id);
        Task<TagDto?> Get(string name);
        Task<List<TagDto>> GetAll();
    }
}
