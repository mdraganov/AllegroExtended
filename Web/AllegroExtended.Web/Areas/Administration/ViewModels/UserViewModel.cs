namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Group { get; set; }
    }
}