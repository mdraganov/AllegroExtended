namespace AllegroExtended.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
       
    public class ClassEventController : BaseController
    {
        public ClassEventController()
        {
        }

        [HttpGet]
        public ActionResult All()
        {
            return this.View();
        }
    }
}
