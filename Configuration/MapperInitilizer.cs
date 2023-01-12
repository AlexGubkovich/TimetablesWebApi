using AutoMapper;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO;

namespace TimetablesProject.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Timetable, TimetableDTO>().ReverseMap();
        }
    }
}