using App.Domain.Core.Permission.Contarcts.Repositories;
using App.Domain.Core.Permission.Contarcts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Permission
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public bool HasPermission(int operatorId, int permissionId)
        {
            if (operatorId==1)
                return true;
            var operatorPermissions = _permissionRepository.GetOperatorPermissions(operatorId);
            return operatorPermissions.Any(x=> x == permissionId);
       
        }
    }
}
