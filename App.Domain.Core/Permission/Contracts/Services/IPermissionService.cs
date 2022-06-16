using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Permission.Contracts.Services
{
    public interface IPermissionService
    {
        bool HasPermission(int operatorId, int permissionId);
    }
}
