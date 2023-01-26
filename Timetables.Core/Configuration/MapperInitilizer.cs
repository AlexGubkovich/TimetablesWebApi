using AutoMapper;
using Timetables.Core.DTOs;
using Timetables.Core.DTOs.GroupDTOs;
using Timetables.Core.DTOs.ScheduleDTOs;
using Timetables.Core.DTOs.SubjectsDTOs;
using Timetables.Core.DTOs.TeacherDTOs;
using Timetables.Core.DTOs.TimetableDTOs;
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
            CreateMap<Subject, CreateSubjectDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<CreateGroupDTO, Group>().ReverseMap();

            CreateMap<Schedule, ScheduleLessonsDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap();
        }
    }
}