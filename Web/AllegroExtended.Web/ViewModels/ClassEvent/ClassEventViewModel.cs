namespace AllegroExtended.Web.ViewModels.ClassEvent
{
    using System;
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ClassEventViewModel : IMapFrom<ClassEvent>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Schedule { get; set; }

        public DateTime NextRunOn { get; set; }

        public DateTime LastRunOn { get; set; }

        public virtual List<Permission> Permissions { get; set; }
    }
}
