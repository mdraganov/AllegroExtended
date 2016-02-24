namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Areas.Administration.ViewModels;
    using AllegroExtended.Web.Controllers;
    using Infrastructure.Mapping;

    public class GroupController : AdminBaseController
    {
        private readonly IGroupService groups;
        private readonly IClassEventService events;
        private readonly IPermissionService permissions;

        public GroupController(IAccountRequestService requests, IGroupService groups, IClassEventService events, IPermissionService permissions)
            : base(requests)
        {
            this.groups = groups;
            this.events = events;
            this.permissions = permissions;
        }

        [HttpGet]
        public ActionResult Details(int id = 1)
        {
            var group = this.groups.GetById(id);
            var model = this.Mapper.Map<GroupDetailsViewModel>(group);
            this.ViewBag.Events = this.events.GetAll().ToList();

            return this.View(model);
        }

        [HttpGet]
        public ActionResult All()
        {
            var groups = this.groups.GetAll().To<GroupJsonViewModel>().ToList();

            return this.View(groups);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult AllAsync()
        {
            var groups = this.groups.GetAll().To<GroupJsonViewModel>().ToList();

            return this.Json(groups, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name)
        {
            try
            {
                this.groups.Add(new Group() { Name = name });

                this.TempData["Notification"] = "Group Created!";

                return this.Redirect("/administration/group/all");
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = ex.Message;

                return this.Redirect("/administration/group/all");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPermission(int id, int eventId, string readOnly)
        {
            try
            {
                var ev = this.events.GetById(eventId);
                var group = this.groups.GetById(id);
                var isReadOnly = false;
                if (readOnly == "true")
                {
                    isReadOnly = true;
                }

                this.permissions.Add(new Permission { IsReadOnly = isReadOnly, ClassEvent = ev, Group = group });

                this.TempData["Notification"] = "Permission Added!";

                return this.Redirect("/administration/group/details/" + id);
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = ex.Message;

                return this.Redirect("/administration/group/details/" + id);
            }
        }

        [HttpGet]
        public ActionResult DeletePermission(int id)
        {
            try
            {
                this.permissions.Delete(id);

                this.TempData["Notification"] = "Permission Deleted!";

                return this.Redirect("/administration/group/all");
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = ex.Message;

                return this.Redirect("/administration/group/all");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this.groups.Delete(id);

                this.TempData["Notification"] = "Group Deleted!";

                return this.Redirect("/administration/group/all");
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = ex.Message;

                return this.Redirect("/administration/group/all");
            }
        }
    }
}