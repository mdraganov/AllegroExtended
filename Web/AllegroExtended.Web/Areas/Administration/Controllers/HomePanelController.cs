namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Web.Controllers;
    using Services.Data;

    public class HomePanelController : AdminBaseController
    {
        public HomePanelController(IAccountRequestService requests)
            : base(requests)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
