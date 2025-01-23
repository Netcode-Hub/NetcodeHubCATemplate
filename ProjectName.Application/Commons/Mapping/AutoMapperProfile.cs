using AutoMapper;
using ProjectName.Application.Features.ToDo.Create;
using ProjectName.Application.Features.ToDo.Delete;
using ProjectName.Application.Features.ToDo.Update;
using ProjectName.Domain.Entities;
namespace ProjectName.Application.Commons.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateToDoTask, ToDoTask>();
            CreateMap<UpdateToDoTask, ToDoTask>();
            CreateMap<DeleteToDoTask, ToDoTask>();
        }
    }
}
