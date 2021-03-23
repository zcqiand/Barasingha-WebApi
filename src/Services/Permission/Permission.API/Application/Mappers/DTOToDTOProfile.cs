using AutoMapper;
using System.Linq;
using UltraNuke.Barasingha.Permission.API.Application.DTO;
using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Permission.API.Application.Mappers
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
