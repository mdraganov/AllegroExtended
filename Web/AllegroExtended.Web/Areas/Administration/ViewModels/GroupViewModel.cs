namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;

    public class GroupViewModel : GroupJsonViewModel
    {
        public string UserName { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}