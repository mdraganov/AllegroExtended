namespace AllegroExtended.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Areas.Users.ViewModels;
    using AllegroExtended.Web.Controllers;

    [AllowAnonymous]
    public class RequestController : BaseController
    {
        private readonly IAccountRequestService requests;
        private readonly IGroupService groups;

        public RequestController(IAccountRequestService requests, IGroupService groups)
        {
            this.requests = requests;
            this.groups = groups;
        }

        [HttpGet]
        public ActionResult Send()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(AccountRequestViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                var group = this.groups.GetById(request.Group);

                var newRequest = new AccountRequest()
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    Remark = request.Remark,
                    Group = group
                };

                this.requests.Add(newRequest);

                this.TempData["Notification"] = "Request sent! You will receive an email with your user name and password upon approval.";

                return this.Redirect("/account/login");
            }

            return this.View(request);
        }
    }
}