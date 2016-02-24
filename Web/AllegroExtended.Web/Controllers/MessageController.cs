namespace AllegroExtended.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;

    public class MessageController : BaseController
    {
        public MessageController()
        {
        }

        public ActionResult All()
        {
            return this.View();
        }
    }
}
