using AutoMapper;
using CNPM.Core.Entities;
namespace CNPM.Core.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDto1002>();
            CreateMap<UserEntity, UserDto1003>();
            CreateMap<UserEntity, UserDto1001>();
            CreateMap<UserDto1005, UserEntity>();
            CreateMap<UserDto1005, UserDto1003>();
            CreateMap<UserDto1006, UserDto1003>();
            CreateMap<UserDto1006, UserEntity>();
            CreateMap<RoleEntity, RoleDto>();
        }
    }
}
