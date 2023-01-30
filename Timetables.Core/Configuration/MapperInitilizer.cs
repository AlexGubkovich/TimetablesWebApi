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

            //Group
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<CreateGroupDTO, Group>();
            CreateMap<UpdateGroupDTO, Group>();

            //Subject
            CreateMap<Subject, SubjectDTO>()
                .ForMember(d => d.TeacherName, s => s.MapFrom(x => x.Teacher.FullName))
                .ReverseMap(); ;
            CreateMap<CreateSubjectDTO, Subject>();
            CreateMap<UpdateSubjectDTO, Subject>();

            //Teacher
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<CreateTeacherDTO, Teacher>();
            CreateMap<UpdateTeacherDTO, Teacher>();

            //Timetable
            CreateMap<Timetable, TimetableDTO>().ReverseMap();
            CreateMap<CreateTimetableDTO, Timetable>();
            CreateMap<UpdateTimetabeDTO, Timetable>();

            //Schedule
            CreateMap<Schedule, ScheduleLessonsDTO>().ReverseMap();
            CreateMap<CreateScheduleDTO, Schedule>();
            CreateMap<UpdateScheduleDTO, Schedule>();

            CreateMap<Lesson, LessonDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
        }
    }
}