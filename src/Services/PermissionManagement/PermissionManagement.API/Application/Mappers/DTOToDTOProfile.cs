using AutoMapper;
using System.Linq;
using UltraNuke.Barasingha.PermissionManagement.API.Application.DTO;
using UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel;

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
            CreateMap<MenuDTO, MenuForGetTreeDTO>();
            CreateMap<MenuDTO, MenuForGetSelectDTO>();
        }
    }
}
