using App.Domain.Core.Permission.Contarcts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Permission
{
    public class PermissionRepository : IPermissionRepository
    {
        public async Task<List<int>> GetOperatorPermissions(int operatorId)
        {
            List<int> permissions = Enumerable.Range(1, 10).ToList();
            return permissions;
        }
    }
}
