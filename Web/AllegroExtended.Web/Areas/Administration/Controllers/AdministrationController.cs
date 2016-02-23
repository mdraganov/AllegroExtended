namespace AllegroExtended.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AllegroExtended.Common;
    using AllegroExtended.Web.Controllers;
    using Services.Data;

    public class AdministrationController : AdminBaseController
    {
        public AdministrationController(IAccountRequestService requests)
            : base(requests)
        {
        }
    }
}
