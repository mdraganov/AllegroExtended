namespace AllegroExtended.Services.Data
{
    using System.Linq;

    using AllegroExtended.Data.Models;

    public interface IGroupService
    {
        Group GetById(int id);

        IQueryable<Group> GetAll();

        void Add(Group group);

        void Delete(int id);
    }
}
