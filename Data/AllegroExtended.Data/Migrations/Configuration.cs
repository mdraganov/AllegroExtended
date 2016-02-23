namespace AllegroExtended.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;
            
            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group { Name = "Back Office" });
                context.Groups.Add(new Group { Name = "Accounting" });
                context.Groups.Add(new Group { Name = "Credit Risk" });
                context.Groups.Add(new Group { Name = "Trading" });
                context.Groups.Add(new Group { Name = "Corporate Finance" });

                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roleAdmin = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                var roleUser = new IdentityRole { Name = GlobalConstants.UserRoleName };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequireDigit = false,
                    RequiredLength = 5,
                    RequireUppercase = false,
                    RequireLowercase = false,
                    RequireNonLetterOrDigit = false
                };

                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
