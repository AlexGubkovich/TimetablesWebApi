using Timetables.Core.IRepository;
using Timetables.Core.IRepository.Base;
using Timetables.Data;

namespace Timetables.Core.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimetableDbContext context;
        private IGroupRepository group;
        private ISubjectRepository subject;
        private ITeacherRepository teacher;

        public UnitOfWork(TimetableDbContext context)
        {
            this.context = context;
        }

        public IGroupRepository Group
        {
            get
            {
                group ??= new GroupRepository(context);
                return group;
            }
        }

        public ISubjectRepository Subject
        {
            get
            {
                subject ??= new SubjectRepository(context);
                return subject;
            }
        }

        public ITeacherRepository Teacher
        {
            get
            {
                teacher ??= new TeacherRepository(context);
                return teacher;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
