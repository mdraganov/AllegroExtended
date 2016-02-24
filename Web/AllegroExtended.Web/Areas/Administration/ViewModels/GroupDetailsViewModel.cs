namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class GroupDetailsViewModel : IMapFrom<Group>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserNames { get; set; }

        public IList<Permission> Permissions { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Group, GroupDetailsViewModel>()
                .ForMember(x => x.UserNames, opt => opt.MapFrom(x => string.Join("; ", x.Users.Select(y => y.UserName))));
            //configuration.CreateMap<Group, GroupDetailsViewModel>()     // TODO: name of classevent
            //    .ForMember(x => x.Permissions, opt => opt.MapFrom(x => string.Join("; ", x.Permissions.Select(y => y.IsReadOnly.ToString()))));
        }
    }
}