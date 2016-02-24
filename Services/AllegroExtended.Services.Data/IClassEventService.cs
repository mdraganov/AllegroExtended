namespace AllegroExtended.Services.Data
{
    using System.Linq;

    using AllegroExtended.Data.Models;

    public interface IClassEventService
    {
        ClassEvent GetById(int id);

        IQueryable<ClassEvent> GetAll();

        void SaveChanges();
    }
}
