using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(AllegroExtended.Web.Startup))]

namespace AllegroExtended.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
