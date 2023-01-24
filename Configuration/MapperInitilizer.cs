using AutoMapper;
using TimetablesProject.Data;
using TimetablesProject.Models.DTO;
using TimetablesProject.Models.DTO.ScheduleDTO;

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

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap(); 
        }
    }
}