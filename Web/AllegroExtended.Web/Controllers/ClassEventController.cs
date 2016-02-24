namespace AllegroExtended.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.ClassEvent;

    public class ClassEventController : BaseController
    {
        private readonly IClassEventService events;
        private readonly IUserService users;

        public ClassEventController(IClassEventService events, IUserService users)
        {
            this.events = events;
            this.users = users;
        }

        [HttpGet]
        public ActionResult All()
        {
            var currenUser = this.users.GetById(this.User.Identity.GetUserId());
            var currenUserWithPermissions = this.users.GetPermissionsById(this.User.Identity.GetUserId());
            this.ViewBag.Permissions = currenUserWithPermissions.FirstOrDefault().Group.Permissions;

            var visibleEvents = this.events.GetAll()
                                .Where(e => e.Permissions.Any(p => p.Group.Id == currenUser.GroupId))
                                .To<ClassEventViewModel>()
                                .ToList();

            return this.View(visibleEvents);
        }

        [HttpGet]
        public ActionResult Trigger(int id = 1)
        {
            // TODO: Connection to the Allegro web service here :)

            var ev = this.events.GetById(id);
            ev.LastRunOn = DateTime.Now;
            this.events.SaveChanges();

            this.TempData["Notification"] = "Event Triggered!";

            return this.Redirect("/ClassEvent/All");
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            var currenUser = this.users.GetById(this.User.Identity.GetUserId());
            var currenUserWithPermissions = this.users.GetPermissionsById(this.User.Identity.GetUserId());
            this.ViewBag.Permissions = currenUserWithPermissions.FirstOrDefault().Group.Permissions;
            this.ViewBag.Id = id;

            var visibleEvents = this.events.GetAll()
                                .Where(e => e.Permissions.Any(p => p.Group.Id == currenUser.GroupId))
                                .To<ClassEventViewModel>()
                                .ToList();

            return this.View(visibleEvents);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClassEventEditViewModel model)
        {
            var ev = this.events.GetById(id);
            ev.Schedule = "Weekly";

            if (model.Mon == "on") ev.Mon = true;
            if (model.Tu == "on") ev.Tu = true;
            if (model.Wed == "on") ev.Wed = true;
            if (model.Thu == "on") ev.Thu = true;
            if (model.Fri == "on") ev.Fri = true;
            if (model.Sat == "on") ev.Sat = true;
            if (model.Sun == "on") ev.Sun = true;

            this.events.SaveChanges();

            this.TempData["Notification"] = "Event schedule changed!";

            return this.Redirect("/classevent/all");
        }

        [HttpGet]
        public ActionResult EditMonthly(int id = 1)
        {
            var currenUser = this.users.GetById(this.User.Identity.GetUserId());
            var currenUserWithPermissions = this.users.GetPermissionsById(this.User.Identity.GetUserId());
            this.ViewBag.Permissions = currenUserWithPermissions.FirstOrDefault().Group.Permissions;
            this.ViewBag.Id = id;

            var visibleEvents = this.events.GetAll()
                                .Where(e => e.Permissions.Any(p => p.Group.Id == currenUser.GroupId))
                                .To<ClassEventViewModel>()
                                .ToList();

            return this.View(visibleEvents);
        }

        [HttpPost]
        public ActionResult EditMonthly(int id, ClassEventEditViewModel model)
        {
            var ev = this.events.GetById(id);
            ev.Schedule = "Monthly";
            ev.MonthlyDate = model.MonthlyDate;
            this.events.SaveChanges();

            this.TempData["Notification"] = "Event schedule changed!";

            return this.Redirect("/classevent/all");
        }

        [HttpGet]
        public ActionResult EditOnce(int id = 1)
        {
            var currenUser = this.users.GetById(this.User.Identity.GetUserId());
            var currenUserWithPermissions = this.users.GetPermissionsById(this.User.Identity.GetUserId());
            this.ViewBag.Permissions = currenUserWithPermissions.FirstOrDefault().Group.Permissions;
            this.ViewBag.Id = id;

            var visibleEvents = this.events.GetAll()
                                .Where(e => e.Permissions.Any(p => p.Group.Id == currenUser.GroupId))
                                .To<ClassEventViewModel>()
                                .ToList();

            return this.View(visibleEvents);
        }

        [HttpPost]
        public ActionResult EditOnce(int id, ClassEventEditViewModel model)
        {
            var ev = this.events.GetById(id);
            ev.Schedule = "Once";
            ev.Date = model.Date;
            this.events.SaveChanges();

            this.TempData["Notification"] = "Event schedule changed!";

            return this.Redirect("/classevent/all");
        }
    }
}
