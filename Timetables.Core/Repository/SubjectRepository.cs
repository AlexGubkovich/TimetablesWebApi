using Microsoft.EntityFrameworkCore;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await Context.Subjects.FindAsync(id);
        }

        public async Task CreateSubject(Subject subject)
        {
            await Create(subject);
        }

        public void UpdateSubject(Subject subject)
        {
            Update(subject);
        }

        public async Task DeleteSubject(int id)
        {
            var subject = await Context.Subjects.FindAsync(id);
            Delete(subject);
        }
    }
}
