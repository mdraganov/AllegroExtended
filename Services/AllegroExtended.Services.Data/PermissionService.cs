namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;

    public class PermissionService : IPermissionService
    {
        private readonly IDbRepository<Permission> permissions;

        public PermissionService(IDbRepository<Permission> permissions)
        {
            this.permissions = permissions;
        }

        public void Add(Permission permission)
        {
            this.permissions.Add(permission);
            this.permissions.Save();
        }

        public void Delete(int id)
        {
            this.permissions.HardDelete(this.permissions.GetById(id));
            this.permissions.Save();
        }

        public IQueryable<Permission> GetAll()
        {
            return this.permissions.All();
        }

        public Permission GetById(int id)
        {
            return this.permissions.GetById(id);
        }
    }
}
