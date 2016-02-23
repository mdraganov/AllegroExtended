namespace AllegroExtended.Services.Data
{
    using System.Linq;

    using AllegroExtended.Data.Models;

    public interface IUserService
    {
        ApplicationUser GetById(string id);

        IQueryable<ApplicationUser> GetAll();

        void Add(ApplicationUser user, string password);

        void Delete(string id);
    }
}