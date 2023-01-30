using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            await FindAll(trackChanges)
            .Include(s => s.Teacher)
            .ToListAsync();

        public async Task<Subject> GetSubjectById(int id, bool trackChanges) =>
            await FindByCondition(s => s.Id == id, trackChanges)
                .Include(s => s.Teacher)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Subject>> GetSubjectsByIds(List<int> subjectsIds, bool trackChanges) =>
            await FindByCondition(s => subjectsIds.Contains(s.Id), trackChanges)
                .Include(s => s.Teacher)
                .ToListAsync();

        public async Task CreateSubject(Subject subject) => await Create(subject);

        public void UpdateSubject(Subject subject) => Update(subject);

        public void DeleteSubject(Subject subject) => Delete(subject);
    }
}
