using AutoMapper;
using Timetables.Core.DTOs;
using Timetables.Core.DTOs.CallScheduleDTO;
using Timetables.Data.Models;

namespace Timetables.Core.Configuration
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