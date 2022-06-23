using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;

namespace App.Infrastructure.Repos.Ef.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        
    }
}