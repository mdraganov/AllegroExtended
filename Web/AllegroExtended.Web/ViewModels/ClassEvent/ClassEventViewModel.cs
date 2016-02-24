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

        public bool? Mon { get; set; }

        public bool? Tu { get; set; }

        public bool? Wed { get; set; }

        public bool? Thu { get; set; }

        public bool? Fri { get; set; }

        public bool? Sat { get; set; }

        public bool? Sun { get; set; }

        public int? MonthlyDate { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? LastRunOn { get; set; }

        public virtual List<Permission> Permissions { get; set; }
    }
}
