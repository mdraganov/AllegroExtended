﻿using System;
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
        public ActionResult Create(UserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var group = this.groups.GetById(model.Group);

                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Group = group };

                this.users.Add(user, model.Password);

                this.TempData["Notification"] = "User Created!";

                return this.Redirect("/administration/request/all");
            }

            this.TempData["Notification"] = string.Join("; ", ModelState.Values
                                                    .SelectMany(x => x.Errors)
                                                    .Select(x => x.ErrorMessage)); //"An error occured. User Not Created!";

            return this.Redirect("/administration/request/all");
        }

        [HttpGet]
        public ActionResult All()
        {
            var users = this.users.GetAll().To<UserListViewModel>().ToList();

            return this.View(users);
        }
    }
}