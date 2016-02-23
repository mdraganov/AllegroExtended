namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Areas.Administration.ViewModels;
    using AllegroExtended.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public abstract class AdminBaseController : BaseController
    {
        protected readonly IAccountRequestService requests;

        public AdminBaseController(IAccountRequestService requests)
        {
            this.requests = requests;
            this.ViewBag.NewAccountRequests = this.requests.GetAllUnread().Count();
            this.ViewBag.AllAccountRequests = this.requests.GetAll().Count();
        }
    }
}