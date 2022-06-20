using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ColorCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
