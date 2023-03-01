using AutoMapper;
using TaskManagementSystemBackend.Dto;

namespace TaskManagementSystemBackend.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisteredUsers,RegisteredUsersDto>().ReverseMap();
            CreateMap<Tasks, TaskDto>().ReverseMap();
            CreateMap<AssignTasks, AssignTaskDto>().ReverseMap();
            CreateMap<UsersSuccess, UserSuccessDto>().ReverseMap();
        }
    }
}
