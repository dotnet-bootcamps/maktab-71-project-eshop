using App.Domain.Core.Permission.Contracts.Repositories;
using App.Domain.Core.Permission.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _appDbContext;
        public PermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<int> GetOperatorPermissions(int operatorId)
        {
            List<Permission> permissions = new List<Permission>() {
            new Permission() { Id = 1 },
            new Permission() { Id = 2 },
            new Permission() { Id = 3 },
            new Permission() { Id = 4 },
            new Permission() { Id = 5 }
                };
            return permissions.Select(p=>p.Id).ToList();
        }
    }
}
