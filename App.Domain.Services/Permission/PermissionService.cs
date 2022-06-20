using App.Domain.Core.Permission.Contracts.Repositories;
using App.Domain.Core.Permission.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Permission
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionQueryRepository _permissionRepository;

        public PermissionService(IPermissionQueryRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public bool HasPermission(int operatorId, int permissionId)
        {
            var permissions = _permissionRepository.GetOperatorPermissions(operatorId);
            var hasPermission=permissions.Any(p=>p==permissionId);
            return hasPermission;
        }
    }
}
