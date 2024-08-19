using API_Entrance.Core.DTO.CategoryDTO;
using API_Entrance.Core.DTO.TaskItemDTO;
using API_Entrance.Core.Entities.Concrete;
using AutoMapper;

namespace API_Entrance.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<TaskItem, GetTaskItemDTO>().ReverseMap();
            CreateMap<TaskItem, CreateTaskItemDTO>().ReverseMap();
            CreateMap<TaskItem, UpdateTaskItemDTO>().ReverseMap()
                .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
