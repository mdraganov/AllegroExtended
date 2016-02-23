namespace AllegroExtended.Web.Controllers
{
    using System.Web.Mvc;

    using AllegroExtended.Services.Web;
    using AutoMapper;
    using Infrastructure.Mapping;

    [Authorize]
    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
