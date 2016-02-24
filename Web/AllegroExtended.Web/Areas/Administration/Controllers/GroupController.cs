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

        public GroupController(IAccountRequestService requests, IGroupService groups)
            : base(requests)
        {
            this.groups = groups;
        }

        [HttpGet]
        public ActionResult Details(int id = 1)
        {
            var group = this.groups.GetById(id);
            var model = this.Mapper.Map<GroupDetailsViewModel>(group);

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