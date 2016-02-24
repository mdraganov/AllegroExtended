namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;

    public class GroupService : IGroupService
    {
        private readonly IDbRepository<Group> groups;

        public GroupService(IDbRepository<Group> groups)
        {
            this.groups = groups;
        }

        public Group GetById(int id)
        {
            var group = this.groups.GetById(id);

            return group;
        }

        public void Add(Group group)
        {
            this.groups.Add(group);
            this.groups.Save();
        }

        public void Delete(int id)
        {
            var group = this.GetById(id);

            this.groups.Delete(group);
            this.groups.Save();
        }

        public IQueryable<Group> GetAll()
        {
            return this.groups.All();
        }
    }
}
