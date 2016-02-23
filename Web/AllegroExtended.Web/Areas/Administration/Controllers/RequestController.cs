namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Areas.Administration.ViewModels;
    using AllegroExtended.Web.Controllers;
    using Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class RequestController : BaseController
    {
        private readonly IAccountRequestService requests;

        public RequestController(IAccountRequestService requests)
        {
            this.requests = requests;
            this.ViewBag.NewAccountRequests = this.requests.GetAllUnread().Count();
            this.ViewBag.AllAccountRequests = this.requests.GetAll().Count();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var request = this.requests.GetById(id);
            var model = this.Mapper.Map<AccountRequestDetailsViewModel>(request);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult All()
        {
            var requests = this.requests.GetAll().To<AccountRequestViewModel>().ToList();

            return this.View(requests);
        }

        [HttpGet]
        public ActionResult AllUnread()
        {
            var requests = this.requests.GetAllUnread().To<AccountRequestViewModel>().ToList();

            return this.View(requests);
        }
    }
}