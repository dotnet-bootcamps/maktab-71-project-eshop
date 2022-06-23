using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Permission.Contarcts.Services
{
    public interface IPermissionService
    {
        Task<bool> HasPermission(int operatorId, int permissionId);
    }
}
