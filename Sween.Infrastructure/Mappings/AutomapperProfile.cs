using AutoMapper;
using Sween.Core.DTOs;
using Sween.Core.Entities;

namespace Sween.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserContact, UserContactDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<UserGroup, UserGroupDTO>().ReverseMap();
        }
    }
}
