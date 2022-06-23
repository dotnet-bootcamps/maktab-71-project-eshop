using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface ICollectionAppService
    {
        Task<List<CollectionDto>> GetAll();
        Task<int> Create(string name);
        Task<CollectionDto> Get(int id);
        Task<CollectionDto> Get(string name);
        Task Update(int id, string name, bool isDeleted);
        Task Delete(int id);
    }
}
