namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Common;
    using AllegroExtended.Data;
    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class UserService : IUserService
    {
        private IDbSet<ApplicationUser> users;

        public UserService(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<ApplicationUser>();
        }

        private IDbSet<ApplicationUser> DbSet { get; }

        private DbContext Context { get; }

        public void Delete(string id)
        {
            var user = this.GetById(id);
            this.DbSet.Remove(user);
            this.Context.SaveChanges();
        }

        public void Add(ApplicationUser user, string password)
        {
            var userStore = new UserStore<ApplicationUser>(this.Context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 5,
                RequireUppercase = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false
            };

            userManager.Create(user, password);

            userManager.AddToRole(user.Id, GlobalConstants.UserRoleName);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.DbSet.AsQueryable();
        }

        public ApplicationUser GetById(string id)
        {
            return this.DbSet.FirstOrDefault(u => u.Id == id);
        }
    }
}
