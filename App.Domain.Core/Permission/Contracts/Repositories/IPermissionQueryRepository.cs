namespace App.Domain.Core.Permission.Contracts.Repositories
{
    public interface IPermissionQueryRepository
    {
        Task<List<int>> GetOperatorPermissions(int operatorId);
    }
}
