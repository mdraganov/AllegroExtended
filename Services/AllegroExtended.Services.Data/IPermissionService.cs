namespace AllegroExtended.Services.Data
{
    using System.Linq;

    using AllegroExtended.Data.Models;

    public interface IPermissionService
    {
        Permission GetById(int id);

        IQueryable<Permission> GetAll();

        void Add(Permission permission);

        void Delete(int id);
    }
}
