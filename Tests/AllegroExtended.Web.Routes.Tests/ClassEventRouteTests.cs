namespace AllegroExtended.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using AllegroExtended.Web.Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class ClassEventRouteTests
    {
        [Test]
        public void TestRouteAll()
        {
            const string Url = "/ClassEvent/All";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<ClassEventController>(c => c.All());
        }

        [Test]
        public void TestRouteTrigger()
        {
            const string Url = "/ClassEvent/Trigger/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<ClassEventController>(c => c.Trigger(1));
        }

        [Test]
        public void TestRouteEdit()
        {
            const string Url = "/ClassEvent/Edit/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<ClassEventController>(c => c.Edit(1));
        }

        [Test]
        public void TestRouteEditMonthly()
        {
            const string Url = "/ClassEvent/EditMonthly/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<ClassEventController>(c => c.EditMonthly(1));
        }

        [Test]
        public void TestRouteEditOnce()
        {
            const string Url = "/ClassEvent/EditOnce/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<ClassEventController>(c => c.EditOnce(1));
        }
    }
}
