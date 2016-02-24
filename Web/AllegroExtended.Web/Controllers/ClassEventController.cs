namespace AllegroExtended.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.ClassEvent;

    public class ClassEventController : BaseController
    {
        private readonly IClassEventService events;
        private readonly IUserService users;

        public ClassEventController(IClassEventService events, IUserService users)
        {
            this.events = events;
            this.users = users;
        }

        [HttpGet]
        public ActionResult All()
        {
            var currenUser = this.users.GetById(this.User.Identity.GetUserId());
            var visibleEvents = this.events.GetAll()
                                .Where(e => e.Permissions.Any(p => p.Group.Id == currenUser.GroupId))
                                .To<ClassEventViewModel>()
                                .ToList();

            return this.View(visibleEvents);
        }
    }
}
