namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;

    public class ClassEventService : IClassEventService
    {
        private readonly IDbRepository<ClassEvent> events;

        public ClassEventService(IDbRepository<ClassEvent> events)
        {
            this.events = events;
        }

        public ClassEvent GetById(int id)
        {
            var events = this.events.GetById(id);

            return events;
        }

        public IQueryable<ClassEvent> GetAll()
        {
            return this.events.All();
        }

        public void SaveChanges()
        {
            this.events.Save();
        }
    }
}
