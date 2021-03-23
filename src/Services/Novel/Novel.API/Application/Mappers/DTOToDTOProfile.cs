using AutoMapper;
using UltraNuke.Barasingha.Novel.API.Application.DTO;
using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Novel.API.Application.Mappers
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
            CreateMap<MainCategoryDTO, MainCategoryForGetSelectDTO>();
            CreateMap<SubCategoryDTO, SubCategoryForGetSelectDTO>();
        }
    }
}
