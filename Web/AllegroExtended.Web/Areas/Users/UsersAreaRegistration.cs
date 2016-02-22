using System.Web.Mvc;

namespace AllegroExtended.Web.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Users",
                "Users/{controller}/{action}/{id}",
                new { controller = "Request", action = "Send", id = UrlParameter.Optional }
            );
        }
    }
}