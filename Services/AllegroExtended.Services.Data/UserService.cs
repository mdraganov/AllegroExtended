namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Data;
    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService()
        {
            this.db = ApplicationDbContext.Create();
        }

        public void Delete(string id)
        {
            var user = this.GetById(id);
            this.db.Users.Remove(user);
            this.db.SaveChanges();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.db.Users.AsQueryable();
        }

        public ApplicationUser GetById(string id)
        {
            return this.db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
