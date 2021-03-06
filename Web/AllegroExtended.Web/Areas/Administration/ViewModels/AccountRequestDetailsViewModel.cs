﻿namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Web.Infrastructure.Mapping;

    public class AccountRequestDetailsViewModel : AccountRequestListViewModel
    {
        public string Remark { get; set; }
    }
}