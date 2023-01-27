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

        public async Task<IEnumerable<Subject>> GetAllSubjects(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Subject> GetSubjectById(int id, bool trackChanges) =>
            await FindByCondition(s => s.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public async Task CreateSubject(Subject subject) => await Create(subject);

        public void UpdateSubject(Subject subject) => Update(subject);

        public void DeleteSubject(Subject subject) => Delete(subject);
    }
}
