using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICollectionQueryRepository
    {
        Task<CollectionDto?> Get(int Id);
        Task<CollectionDto?> Get(string name);
        Task<List<CollectionDto>> GetAll();
    }
}
