using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface ICollectionService
    {
        //Query
        Task<List<CollectionDto>> GetAll();
        Task<CollectionDto?> Get(int id);
        Task<CollectionDto?> Get(string name);

        //Command
        Task<int> Create(string name);
        Task Delete(int id);
        Task Update(int id, string name, bool isDeleted);

        //Ensurness
        Task EnsureCollectionIsNotExist(string name);
        Task EnsureCollectionIsExist(string name);
        Task EnsureCollectionIsExist(int id);
    }
}
