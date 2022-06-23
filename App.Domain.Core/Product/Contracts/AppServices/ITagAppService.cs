using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface ITagAppService
    {
        Task<List<TagDto>> GetAll();
        Task<int> Create(string name, int tagCategoryId, bool hasValue);
        Task<TagDto> Get(int id);
        Task<TagDto> Get(string name);
        Task Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted);
        Task Delete(int id);
    }
}
