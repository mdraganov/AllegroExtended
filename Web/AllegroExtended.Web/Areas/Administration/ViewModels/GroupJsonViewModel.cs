namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Web.Infrastructure.Mapping;

    public class GroupJsonViewModel : IMapFrom<Group>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}