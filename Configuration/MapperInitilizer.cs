using AutoMapper;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO;
using TimetablesProject.Models.DTO.CallScheduleDTO;

namespace TimetablesProject.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            AllowNullCollections = true;

            CreateMap<Timetable, TimetableDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();

            CreateMap<CallSchedule, CallScheduleDTO>().ReverseMap();
            CreateMap<CallSchedule, CreateCallScheduleDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap(); 
        }
    }
}