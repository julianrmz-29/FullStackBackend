using AutoMapper;
using ToDoBackend.Models;
using ToDoBackend.Models.DTO;

namespace ToDoBackend.ConfigMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ToDoAddEditDTO, ToDoModel>();
        }
    }
}
