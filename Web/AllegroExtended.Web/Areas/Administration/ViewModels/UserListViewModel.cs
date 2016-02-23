namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class UserListViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Group { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserListViewModel>()
                .ForMember(x => x.Group, opt => opt.MapFrom(x => x.Group.Name));
        }
    }
}