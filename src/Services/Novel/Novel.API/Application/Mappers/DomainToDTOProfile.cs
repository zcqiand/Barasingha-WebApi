using AutoMapper;
using UltraNuke.Barasingha.Novel.API.Application.DTO;
using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Novel.API.Application.Mappers
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

            CreateMap<MainCategory, MainCategoryDTO>();
            CreateMap<SubCategory, SubCategoryForGetDTO>();
            CreateMap<Book, BookForGetDTO>()
                .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategory.Id))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.BookStatusName, opt => opt.Ignore())
                .ForMember(dest => dest.SerialStatusName, opt => opt.Ignore());
            CreateMap<Segment, SegmentForGetDTO>();
            CreateMap<Chapter, ChapterForGetDTO>();
        }
    }
}
