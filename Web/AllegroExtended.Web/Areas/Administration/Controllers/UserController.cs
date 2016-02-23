using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Areas.Administration.ViewModels;
    using AllegroExtended.Web.Controllers;
    using Data;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserController : AdminBaseController
    {
        private readonly IUserService users;
        private readonly IGroupService groups;

        public UserController(IAccountRequestService requests, IUserService users, IGroupService groups)
            : base(requests)
        {
            this.users = users;
            this.groups = groups;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model, int requestId)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var group = this.groups.GetById(model.Group);

                    var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Group = group };

                    this.users.Add(user, model.Password);

                    this.TempData["Notification"] = "User Created!";

                    this.requests.Delete(requestId);

                    return this.Redirect("/administration/request/all");
                }

                this.TempData["Notification"] = string.Join("; ", ModelState.Values
                                                        .SelectMany(x => x.Errors)
                                                        .Select(x => x.ErrorMessage));

                return this.Redirect("/administration/request/all");
            }
            catch (Exception ex)
            {
                this.TempData["Notification"] = ex.Message;

                return this.Redirect("/administration/request/all");
            }
        }

        [HttpGet]
        public ActionResult All()
        {
            var users = this.users.GetAll().To<UserListViewModel>().ToList();

            return this.View(users);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            this.users.Delete(id);

            this.TempData["Notification"] = "User Deleted!";

            return this.Redirect("/administration/user/all");
        }
    }
}