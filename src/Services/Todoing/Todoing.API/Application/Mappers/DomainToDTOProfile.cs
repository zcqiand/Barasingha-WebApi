using AutoMapper;
using UltraNuke.Barasingha.Todoing.Domain.AggregatesModel;
using UltraNuke.Barasingha.Todoing.API.Application.DTO;

namespace UltraNuke.Barasingha.Todoing.API.Application.Mappers
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
            CreateMap<Todo, TodoDTO>();
        }
    }
}
