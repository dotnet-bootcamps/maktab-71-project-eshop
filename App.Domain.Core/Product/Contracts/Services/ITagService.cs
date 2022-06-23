using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface ITagService
    {
        //Query
        Task<List<TagDto>> GetAll();
        Task<TagDto?> Get(int id);
        Task<TagDto?> Get(string name);

        //Command
        Task<int> Create(string name, int tagCategoryId, bool hasValue);
        Task Delete(int id);
        Task Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted);

        //Ensurness
        Task EnsureTagIsNotExist(string name);
        Task EnsureTagIsExist(string name);
        Task EnsureTagIsExist(int id);
    }
}
