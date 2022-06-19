using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class BaseDataQueryRepository : IBaseDataQueryRepository
    {
        private readonly AppDbContext _context;

        public BaseDataQueryRepository(AppDbContext context)
        {
            _context = context;
        }
       
    }
}
