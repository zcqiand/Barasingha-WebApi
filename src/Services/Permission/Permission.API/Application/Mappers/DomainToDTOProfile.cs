using AutoMapper;
using System.Linq;
using UltraNuke.Barasingha.Permission.API.Application.DTO;
using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Permission.API.Application.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainToDTOProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainToDTOProfile()
        {
            CreateMap<Menu, MenuDTO>();
            CreateMap<Menu, MenuForGetTreeDTO>();
            CreateMap<Menu, MenuForGetSelectDTO>();
            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.MenuIds, opt => opt.MapFrom(src => src.Menus.Select(s => s.Id)));
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.GenderName, opt => opt.Ignore())
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(s => s.Id)));
        }
    }
}
