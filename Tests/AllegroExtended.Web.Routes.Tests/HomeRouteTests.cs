namespace AllegroExtended.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using AllegroExtended.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class HomeRouteTests
    {
        [Test]
        public void TestRouteIndex()
        {
            const string Url = "/Home/Index";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }
    }
}
