namespace AllegroExtended.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

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
            const string AdministratorPassword = "admin";

            if (!context.Groups.Any())
            {
                var groups = new List<Group>();

                groups.Add(new Group { Name = "Back Office" });
                groups.Add(new Group { Name = "Accounting" });
                groups.Add(new Group { Name = "Credit Risk" });
                groups.Add(new Group { Name = "Trading" });
                groups.Add(new Group { Name = "Corporate Finance" });
                groups.Add(new Group { Name = "Administration" });

                foreach (var group in groups)
                {
                    context.Groups.Add(group);
                }

                var events = new List<ClassEvent>();

                events.Add(
                    new ClassEvent()
                    {
                        Name = "Valuation",
                        Description = "Calculates the whole potrfolio valuation",
                        Schedule = "Weekly"
                    });
                events.Add(
                    new ClassEvent()
                    {
                        Name = "Invoice",
                        Description = "Calculates invoices for the month",
                        Schedule = "Monthly",
                        MonthlyDate = 28
                    });
                events.Add(
                    new ClassEvent()
                    {
                        Name = "Ticket",
                        Description = "Processes tickets for the day",
                        Schedule = "Weekly"
                    });
                events.Add(
                    new ClassEvent()
                    {
                        Name = "Import Forward Prices",
                        Description = "Import quotes from fx quotes proider",
                        Schedule = "Weekly"
                    });
                events.Add(
                    new ClassEvent()
                    {
                        Name = "P&L",
                        Description = "Calculates Profit and Loss",
                        Schedule = "Monthly"
                    });
                events.Add(
                    new ClassEvent()
                    {
                        Name = "Risk Exposure",
                        Description = "Calculates Credit Risk Exposure",
                        Schedule = "Monthly"
                    });

                foreach (var ev in events)
                {
                    context.ClassEvents.Add(ev);
                }

                context.Permissions.Add(new Permission { ClassEvent = events[0], Group = groups[2], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[0], Group = groups[3], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[1], Group = groups[1], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[0], Group = groups[5], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[1], Group = groups[5], IsReadOnly = true });
                context.Permissions.Add(new Permission { ClassEvent = events[2], Group = groups[5], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[3], Group = groups[5], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[4], Group = groups[5], IsReadOnly = false });
                context.Permissions.Add(new Permission { ClassEvent = events[5], Group = groups[5], IsReadOnly = false });

                context.SaveChanges();

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roleAdmin = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                var roleUser = new IdentityRole { Name = GlobalConstants.UserRoleName };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);

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

                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName, Group = groups[5] };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
