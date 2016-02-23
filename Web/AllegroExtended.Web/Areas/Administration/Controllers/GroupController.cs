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
            var request = this.requests.GetById(id);
            var model = this.Mapper.Map<AccountRequestDetailsViewModel>(request);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult All()
        {
            var groups = this.groups.GetAll().To<GroupViewModel>().ToList();

            return this.View(groups);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult AllAsync()
        {
            var groups = this.groups.GetAll().To<GroupJsonViewModel>().ToList();

            return this.Json(groups, JsonRequestBehavior.AllowGet);
        }
    }
}