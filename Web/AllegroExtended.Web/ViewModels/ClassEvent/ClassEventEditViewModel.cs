namespace AllegroExtended.Web.ViewModels.ClassEvent
{
    using System;
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ClassEventEditViewModel
    {
        public string Mon { get; set; }

        public string Tu { get; set; }

        public string Wed { get; set; }

        public string Thu { get; set; }

        public string Fri { get; set; }

        public string Sat { get; set; }

        public string Sun { get; set; }

        public int? MonthlyDate { get; set; }

        public DateTime? Date { get; set; }
    }
}
