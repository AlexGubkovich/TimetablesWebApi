using Microsoft.EntityFrameworkCore;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class TimetableRepository : RepositoryBase<Timetable>, ITimetableRepository
    {
        public TimetableRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Timetable>> GetAllTimetables(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Timetable> GetTimetableById(int id, bool trackChanges) =>
            await FindByCondition(t => t.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Timetable>> GetTimetablesByGroupId(int groupId, bool trackChanges)
        {
            return await FindByCondition(t => t.GroupId == groupId, trackChanges)
                .Include(p => p.Classes)
                .Include(p => p.Subjects).ThenInclude(p => p.Teacher)
                .ToListAsync();
        }

        public async Task CreateTimetable(Timetable timetable) => await Create(timetable);

        public void UpdateTimetable(Timetable timetable) => Update(timetable);

        public void DeleteTimetable(Timetable timetable) => Delete(timetable);
    }
}
