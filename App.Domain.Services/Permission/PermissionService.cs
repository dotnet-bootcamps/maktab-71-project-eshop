using App.Domain.Core.Permission.Contarcts.Repositories;
using App.Domain.Core.Permission.Contarcts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
        public async Task EnsureHasPermission(int operatorId, int permissionId)
        {
            var operatorHasPermission = (await _permissionRepository.GetOperatorPermissions(operatorId)).Any(x => x == permissionId);
            if (!operatorHasPermission)
                throw new UnauthorizedAccessException("The operator has not permission to this operation");
        }
    }
}
