namespace App.Domain.Core.Permission.Contracts.Repositories
{
    public interface IPermissionQueryRepository
    {
        List<int> GetOperatorPermissions(int operatorId);
    }
}
