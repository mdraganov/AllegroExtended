namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using System;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AllegroExtended.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class AccountRequestListViewModel : IMapFrom<AccountRequest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Group { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<AccountRequest, AccountRequestListViewModel>()
                .ForMember(x => x.Group, opt => opt.MapFrom(x => x.Group.Name));
        }
    }
}