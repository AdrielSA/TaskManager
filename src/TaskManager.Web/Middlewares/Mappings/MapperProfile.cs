using AutoMapper;
using TaskManager.Web.Models;

namespace TaskManager.Web.Middlewares.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Core.Entities.Task, TaskViewModel>()
                .ReverseMap()
                .ForMember(e => e.CreationDate, m => m.Ignore());
        }
    }
}
