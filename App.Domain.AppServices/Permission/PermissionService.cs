using App.Domain.Core.Permission.Contracts.AppServices;
using App.Domain.Core.Permission.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Permission
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
            return _permissionRepository.GetOperatorPermissions(operatorId).Any(p => p == permissionId);
        }
    }
}
