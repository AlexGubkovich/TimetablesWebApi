using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TimetablesProject.Models;

namespace TimetablesProject.Data
{
    public static class SeedTimetableData
    {
        public static async Task GenerateSeedTimetableDataAsync(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var databaseContext = provider.GetRequiredService<TimetableDbContext>();
                
                databaseContext.Database.Migrate();
                
                await AddEntities(databaseContext);

            }
        }

        private static async Task AddEntities(TimetableDbContext context)
        {
            List<Lesson> lessons;
            if (!context.Lessons.Any())
            {
                lessons = new List<Lesson> {
                new Lesson{ Start = new TimeSpan(9,0,0), End = new TimeSpan(10,20,0)},
                new Lesson{ Start = new TimeSpan(10,30,0), End = new TimeSpan(11,50,0)},
                new Lesson{ Start = new TimeSpan(12,10,0), End = new TimeSpan(13,30,0)},
                new Lesson{ Start = new TimeSpan(13,40,0), End = new TimeSpan(15,0,0)}
            };
                context.Lessons.AddRange(lessons);
            }
            else
            {
                lessons = context.Lessons.ToList();
            }

            List<CallSchedule> callSedules;
            if (!context.CallSedules.Any())
            {
                callSedules = new List<CallSchedule> {
                new CallSchedule { Lessons = new List<Lesson>{ lessons[0], lessons[1], lessons[2], lessons[3], }, IsActive = true, Name = "Весенне расписание" }
            };
                context.CallSedules.AddRange(callSedules);
            }
            else
            {
                callSedules = context.CallSedules.ToList();
            }


            List<Group> groups;
            if (!context.Groups.Any())
            {
                groups = new List<Group> {
                new Group{ Name = "ИПЗ-20" },
                new Group{ Name = "АКТ-20" }
            };
                context.Groups.AddRange(groups);
            }
            else
            {
                groups = context.Groups.ToList();
            }

            List<Teacher> teachers;
            if (!context.Teachers.Any())
            {
                teachers = new List<Teacher> {
                new Teacher{ Id = 1, FullName = "Максимов В.И." },
                new Teacher{ Id = 2, FullName = "Тарасюк А.И." },
                new Teacher{ Id = 3, FullName = "Медведева О.А" }
            };
                context.Teachers.AddRange(teachers);
            }
            else
            {
                teachers = context.Teachers.ToList();
            }

            List<Subject> subjects;
            if (!context.Subjects.Any())
            {
                subjects = new List<Subject> {
                new Subject{ Name = "Линейная математика", Teacher = teachers[0] },
                new Subject{ Name = "ООП", Teacher = teachers[1] },
                new Subject{ Name = "Английский", Teacher = teachers[2] },

                new Subject{ Name = "Конструирование", Teacher = teachers[1] },
                new Subject{ Name = "Робототехника", Teacher = teachers[0] },
                new Subject{ Name = "Моделирование", Teacher = teachers[2] },
            };
                context.Subjects.AddRange(subjects);
            }
            else
            {
                subjects = context.Subjects.ToList();
            }

            List<Class> classes;
            if (!context.Classes.Any())
            {
                classes = new List<Class> {
                new Class { Number = 1},
                new Class { Number = 2},
                new Class { Number = 3},
                new Class { Number = 4},
                new Class { Number = 5},
            };
                context.Classes.AddRange(classes);
            }
            else
            {
                classes = context.Classes.ToList();
            }

            List<Timetable> timetables;
            if (!context.Timetables.Any())
            {
                timetables = new List<Timetable> {
                new Timetable{ Date = DayOfWeek.Monday, Group = groups[0], GroupId = groups[0].Id, Subjects = new List<Subject> { subjects[0], subjects[1] }, Classes = new List<Class> { classes[0], classes[2] } },
                new Timetable{ Date = DayOfWeek.Tuesday, Group = groups[0], GroupId = groups[0].Id, Subjects = new List<Subject> { subjects[2], subjects[1] }, Classes = new List<Class> { classes[1], classes[2] } },
                new Timetable{ Date = DayOfWeek.Wednesday, Group = groups[0], GroupId = groups[0].Id, Subjects = new List <Subject> { subjects[1] }, Classes = new List<Class> { classes[2] } },
                new Timetable{ Date = DayOfWeek.Thursday, Group = groups[0], GroupId = groups[0].Id, Subjects =  new List<Subject> { subjects[2], subjects[0] }, Classes = new List<Class> { classes[0], classes[1] } },
                new Timetable{ Date = DayOfWeek.Friday, Group = groups[0], GroupId = groups[0].Id, Subjects = new List <Subject> { subjects[0], subjects[1] }, Classes = new List<Class> { classes[0], classes[1] } },

                new Timetable{ Date = DayOfWeek.Tuesday, Group = groups[1], GroupId = groups[1].Id, Subjects = new List<Subject> { subjects[3], subjects[4] }, Classes = new List<Class> { classes[2], classes[3] } },
                new Timetable{ Date = DayOfWeek.Thursday, Group = groups[1], GroupId = groups[1].Id, Subjects = new List<Subject> { subjects[4], subjects[3], subjects[5] }, Classes = new List<Class> { classes[0], classes[1], classes[3] } },
                new Timetable{ Date = DayOfWeek.Friday, Group = groups[1], GroupId = groups[1].Id, Subjects = new List<Subject> { subjects[4], subjects[5], subjects[2] }, Classes = new List<Class> { classes[0], classes[1], classes[2] } },
            };
                context.Timetables.AddRange(timetables);
            }

            await context.SaveChangesAsync();
        }
    }
}
