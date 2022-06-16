using OperatorEntities = App.Domain.Core.Operator.Entities;

namespace App.Domain.Core.Permission.Contracts.AppServices
{
    public interface IPermissionService
    {
        public bool HasPermission(int operatorId, int permissionId);
    }
}
