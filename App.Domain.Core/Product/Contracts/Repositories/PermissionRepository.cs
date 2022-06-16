using App.Domain.Core.Permission.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        public List<int> GetOperatorPermissions(int operatorId)
        {
            var result=new List<int>();
            result.Add(3);
            result.Add(8);
            result.Add(9);
            return result;
        }
    }
}
