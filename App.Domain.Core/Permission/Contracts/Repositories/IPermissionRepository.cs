namespace App.Domain.Core.Permission.Contracts.Repositories
{
    public interface IPermissionRepository
    {
        List<int> GetOperatorPermissions(int operatorId);
    }
}
