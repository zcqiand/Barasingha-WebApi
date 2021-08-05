using AutoMapper;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class DTOToDTOProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DTOToDTOProfile()
        {
            CreateMap<MenuForGetDTO, MenuForGetTreeTableDTO>();
            CreateMap<MenuForGetDTO, MenuForGetTreeSelectDTO>();
        }
    }
}
