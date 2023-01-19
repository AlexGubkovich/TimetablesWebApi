using AutoMapper;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO;

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
            CreateMap<Lesson, LessonDTO>().ReverseMap();

            
        }
    }
}