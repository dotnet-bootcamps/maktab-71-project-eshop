using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class BaseDataQueryRepository : IBaseDataQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public BaseDataQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
