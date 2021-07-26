using AutoMapper;
using Todo.Dtos;
using Todo.Entities;

namespace Todo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoDto>().ReverseMap();
        }
    }
}
