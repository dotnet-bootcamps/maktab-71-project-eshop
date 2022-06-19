using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class BaseDataCommandRepository : IBaseDataCommandRepository
    {
        private readonly AppDbContext _context;

        public BaseDataCommandRepository(AppDbContext context)
        {
            _context = context;
        }
       
    }
}
