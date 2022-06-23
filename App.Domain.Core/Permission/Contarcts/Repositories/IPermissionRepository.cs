using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Permission.Contarcts.Repositories
{
    public interface IPermissionRepository
    {
        Task<List<int>> GetOperatorPermissions(int operatorId);
    }
}
