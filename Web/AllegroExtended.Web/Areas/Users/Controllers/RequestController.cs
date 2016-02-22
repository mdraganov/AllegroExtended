namespace AllegroExtended.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Web.Controllers;
    using ViewModels;

    public class RequestController : BaseController
    {
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
                this.TempData["Notification"] = "Request sent! You will receive an email with user name and password upon approval.";

                return this.Redirect("/account/login");
            }

            return this.View(request);
        }
    }
}